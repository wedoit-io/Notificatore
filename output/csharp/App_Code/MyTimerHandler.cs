// **********************************************
// TimerHandler Handler
// Instant WEB Application: www.progamma.com
// Project : Mobile Manager
// **********************************************
using System;
using System.Reflection;
using com.progamma.ids;
using com.progamma;

// **********************************************
// TimerHandler Handler
// **********************************************
[Serializable]
public sealed class MyTimerHandler : TimerHandler
{
  static int TIM_OFFSET = 0;
  static int TIM_BASEIDX = 0;

  // **********************************************
  // Costruttore
  // **********************************************
  public MyTimerHandler(WebEntryPoint p)
    : base(p)
  {
    //
    Timers[MyGlb.TIM_REFRESPOLLIN] = new ATimer();
    Timers[MyGlb.TIM_REFRESPOLLIN].iGuid = "66724C77-DFE9-4B98-A5D7-0B14E084232F";
    Timers[MyGlb.TIM_REFRESPOLLIN].Index = MyGlb.TIM_REFRESPOLLIN;
    Timers[MyGlb.TIM_REFRESPOLLIN].Code = "REFRESPOLLIN";
    Timers[MyGlb.TIM_REFRESPOLLIN].NumTicks = 0;
    Timers[MyGlb.TIM_REFRESPOLLIN].Interval = 2;
    Timers[MyGlb.TIM_REFRESPOLLIN].InitialEnabled = true;
    Timers[MyGlb.TIM_REFRESPOLLIN].set_bEnabled(true);
    Timers[MyGlb.TIM_REFRESPOLLIN].ServerSession = true;
    //
  }

  // **********************************************
  // Appende gli oggetti al TimerHandler fornito
  // **********************************************
  public override int GetBaseIndex()
  {
    return MyTimerHandler.TIM_BASEIDX;
  }
  public override void SetBaseIndex(int newIndex)
  {
    MyTimerHandler.TIM_BASEIDX = newIndex;
  }
  public override void AppendTo(TimerHandler Dst)
  {
    // Se ho timer
    if (Timers.Length > 0)
    {
      // Se è la prima volta, appendo
      if (MyTimerHandler.TIM_OFFSET == 0)
      {
        // Per cominciare appendo tutti i Timers contenuti in Dst dentro al mio array
        int idx = Dst.Timers.Length;
        if (idx == 0) idx = 1;    // L'array dei timer è 1-based
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
          ATimer[] oldTimers = Timers;
          Timers = new ATimer[baseidx + oldTimers.Length];
          for (int i = baseidx; i < Timers.Length; i++)
            Timers[i] = oldTimers[i - baseidx];
          //
          // Questo è l'indice del mio primo oggetto
          MyTimerHandler.TIM_OFFSET = baseidx;
          //
          idx = baseidx + 1;
          Array.Resize(ref Dst.Timers, Timers.Length);
        }
        else
          Array.Resize(ref Dst.Timers, idx + Timers.Length - 1);
        //
        for (int i = 1; i < Timers.Length; i++)
        {
          ATimer t = Timers[i];
          if (t == null)
            continue;
          //
          if (t.IdxForm > 0)
            t.IdxForm += MainFrm.CompOwner.iFrmOffs.intValue();   // Shifto le referenze alle form
          //
          t.Index = idx;
          Dst.Timers[idx++] = t;
        }
        //
        // Se non l'ho ancora fatto, il mio offset è il numero di commandset di tutti i miei padri...
        // Per calcolarlo guardo a dove è finito il mio primo timer (l'elemento 0 è NULL)
        // Quello è l'offset dei miei timer rispetto all'array che contiene tutti i timer di tutti i componenti
        if (MyTimerHandler.TIM_OFFSET == 0)
          MyTimerHandler.TIM_OFFSET = Timers[1].Index - 1;
        //
        // Shifto tutte le costanti contenute in MyGlb
        String tn = (MainFrm.CompNameSpace != null ? MainFrm.CompNameSpace + "." : "");
        FieldInfo[] props = Assembly.GetExecutingAssembly().GetType(tn + "MyGlb").GetFields();
        for (int j = 0; j < props.Length; j++)
        {
          FieldInfo p = props[j];
          if (p.Name.StartsWith("TIM_") || p.Name.Equals("MAX_TIMERS"))
            p.SetValue(null, ((int)p.GetValue(null)) + MyTimerHandler.TIM_OFFSET);
        }
        //
        // Aggiorno l'indice di "riempimento" del DST. Se verrà caricato un nuovo componente 
        // i suoi oggetti dovranno finire dopo il mio ultimo oggetto
        Dst.SetBaseIndex(Dst.Timers.Length);
      }
      else  // Il componente è già stato inizializzato in precedenza... infilo i timer dove li ho messi l'ultima volta
      {
        // L'array di mio padre potrebbe essere più grande del mio se i componenti sono "dinamici" e vengono caricati in un 
        // ordine diverso da quello precedente (es: app->cmp1->cmp2 e poi, in una sessione differente app->cmp2->cmp1)
        Array.Resize(ref Dst.Timers, Math.Max(Timers.Length, Dst.Timers.Length));
        Array.Copy(Timers, MyTimerHandler.TIM_OFFSET + 1, Dst.Timers, MyTimerHandler.TIM_OFFSET + 1, Timers.Length - (MyTimerHandler.TIM_OFFSET + 1));
      }
    }
  }
}
