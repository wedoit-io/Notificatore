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
        Array.Resize(ref Dst.Indicators, idx + Indicators.Length - 1);
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
      }
      else  // Il componente è già stato inizializzato in precedenza... infilo gli indicatori dove li ho messi l'ultima volta
      {
        // L'array di mio padre potrebbe essere più grande del mio se i componenti sono "dinamici" e vengono caricati in un 
        // ordine diverso da quello precedente (es: app->cmp1->cmp2 e poi, in una sessione differente app->cmp2->cmp1)
        Array.Resize(ref Dst.Indicators, Math.Max(Indicators.Length, Dst.Indicators.Length));
        Array.Copy(Indicators, MyIndHandler.IND_OFFSET + 1, Dst.Indicators, MyIndHandler.IND_OFFSET + 1, Indicators.Length - (MyIndHandler.IND_OFFSET + 1));
      }
      //
      // Se non l'ho ancora fatto shifto tutte le costanti contenute in MyGlb
      if (MyIndHandler.IND_OFFSET == 0)
      {
        // Il mio offset è il numero di indicatori di tutti i miei padri...
        // Per calcolarlo guardo a dove è finito il mio primo indicatore (l'elemento 0 è NULL)
        // Quello è l'offset dei miei indicatori rispetto all'array che contiene tutti i indicatori di tutti i componenti
        MyIndHandler.IND_OFFSET = Indicators[1].Index - 1;
        //
        String tn = (MainFrm.CompNameSpace != null ? MainFrm.CompNameSpace + "." : "");
        FieldInfo[] props = Assembly.GetExecutingAssembly().GetType(tn + "MyGlb").GetFields();
        for (int j = 0; j < props.Length; j++)
        {
          FieldInfo p = props[j];
          if (p.Name.StartsWith("IND_") || p.Name.Equals("MAX_INDICATORS"))
            p.SetValue(null, ((int)p.GetValue(null)) + MyIndHandler.IND_OFFSET);
        }
      }
    }
  }
}
