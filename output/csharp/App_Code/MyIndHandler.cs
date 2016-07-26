// **********************************************
// Indicator Handler
// Instant WEB Application: www.progamma.com
// Project : Mobile Manager
// **********************************************
using System;
using System.Reflection;
using com.progamma;
using com.progamma.ids;

// **********************************************
// Indicator Handler
// **********************************************
[Serializable]
class MyIndHandler : IndHandler
{
  static int IND_OFFSET = 0;
  static int IND_BASEIDX = 0;

  // **********************************************
  // Costruttore
  // **********************************************
  public MyIndHandler(WebEntryPoint p)
    : base(p)
  {
    //
    //		
  }

  // **********************************************
  // Appende gli oggetti al TimerHandler fornito
  // **********************************************
  public override int GetBaseIndex()
  {
    return MyIndHandler.IND_BASEIDX;
  }
  public override void SetBaseIndex(int newIndex)
  {
    MyIndHandler.IND_BASEIDX = newIndex;
  }
  public override void AppendTo(IndHandler Dst)
  {
    // Se ho indicatori
    if (Indicators.Length > 0)
    {
      // Se è la prima volta, appendo
      if (MyIndHandler.IND_OFFSET == 0)
      {
        // Per cominciare appendo tutti gli Indicators contenuti in Dst dentro al mio array
        int idx = Dst.Indicators.Length;
        if (idx == 0) idx = 1;    // L'array dei cmdset è 1-based
        //
        // Non ho mai caricato prima questo componente ma l'array che riceverà i miei oggetti
        // ha un baseidx diverso da 0 (questo può succedere se vengono caricati componenti dinamici
        // e vengono caricati in ordine diverso. Es: sessione 1 carica Comp1, sessione 2 carica Comp2
        // in questo caso la sessione 2 non ha mai caricato Comp1 ma se dovesse farlo deve esserci spazio
        // per i suoi oggetti nello stesso posto in cui erano prima!)
        // Quindi se il componente base ha delle zone che non possono essere occupate (causa componenti
        // già caricati in altre sessioni) sposto i miei oggetti in avanti di quell'offset così la
        // Append funziona correttamente
        int baseidx = Dst.GetBaseIndex();
        if (baseidx != 0)
        {
          baseidx--;    // L'array dei cmdset è 1-based
          //
          // Baseidx è l'indice del primo slot libero. Shifto i miei oggetti in avanti di baseidx
          // (in altre parole inserisco baseidx nulli all'inizio dell'array)
          AIndicator[] oldIndicators = Indicators;
          Indicators = new AIndicator[baseidx + oldIndicators.Length];
          for (int i = baseidx; i < Indicators.Length; i++)
            Indicators[i] = oldIndicators[i - baseidx];
          //
          // Questo è l'indice del mio primo oggetto
          MyIndHandler.IND_OFFSET = baseidx;
          //
          idx = baseidx + 1;
          Array.Resize(ref Dst.Indicators, Indicators.Length);
        }
        else
          Array.Resize(ref Dst.Indicators, idx + Indicators.Length - 1);
        //
        for (int i = 1; i < Indicators.Length; i++)
        {
          AIndicator ind = Indicators[i];
          if (ind == null)
            continue;
          //
          if (ind.IdxForm > 0)
            ind.IdxForm += MainFrm.CompOwner.iFrmOffs.intValue();   // Shifto le referenze alle form
          //
          ind.Index = idx;
          Dst.Indicators[idx++] = ind;
        }
        //
        // Se non l'ho ancora fatto, il mio offset è il numero di commandset di tutti i miei padri...
        // Per calcolarlo guardo a dove è finito il mio primo indicatore (l'elemento 0 è NULL)
        // Quello è l'offset dei miei indicatori rispetto all'array che contiene tutti i indicatori di tutti i componenti
        if (MyIndHandler.IND_OFFSET == 0)
          MyIndHandler.IND_OFFSET = Indicators[1].Index - 1;
        //
        // Shifto tutte le costanti contenute in MyGlb
        String tn = (MainFrm.CompNameSpace != null ? MainFrm.CompNameSpace + "." : "");
        FieldInfo[] props = Assembly.GetExecutingAssembly().GetType(tn + "MyGlb").GetFields();
        for (int j = 0; j < props.Length; j++)
        {
          FieldInfo p = props[j];
          if (p.Name.StartsWith("IND_") || p.Name.Equals("MAX_INDICATORS"))
            p.SetValue(null, ((int)p.GetValue(null)) + MyIndHandler.IND_OFFSET);
        }
        //
        // Aggiorno l'indice di "riempimento" del DST. Se verrà caricato un nuovo componente 
        // i suoi oggetti dovranno finire dopo il mio ultimo oggetto
        Dst.SetBaseIndex(Dst.Indicators.Length);
      }
      else  // Il componente è già stato inizializzato in precedenza... infilo gli indicatori dove li ho messi l'ultima volta
      {
        // L'array di mio padre potrebbe essere più grande del mio se i componenti sono "dinamici" e vengono caricati in un 
        // ordine diverso da quello precedente (es: app->cmp1->cmp2 e poi, in una sessione differente app->cmp2->cmp1)
        Array.Resize(ref Dst.Indicators, Math.Max(Indicators.Length, Dst.Indicators.Length));
        Array.Copy(Indicators, MyIndHandler.IND_OFFSET + 1, Dst.Indicators, MyIndHandler.IND_OFFSET + 1, Indicators.Length - (MyIndHandler.IND_OFFSET + 1));
      }
    }
  }
}
