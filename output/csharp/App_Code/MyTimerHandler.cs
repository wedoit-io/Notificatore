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
    Timers[MyGlb.TIM_REFRESPOLLIN].Interval = 4;
    Timers[MyGlb.TIM_REFRESPOLLIN].InitialEnabled = true;
    Timers[MyGlb.TIM_REFRESPOLLIN].set_bEnabled(true);
    Timers[MyGlb.TIM_REFRESPOLLIN].ServerSession = true;
    //
  }

  // **********************************************
  // Appende gli oggetti al TimerHandler fornito
  // **********************************************
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
        Array.Resize(ref Dst.Timers, idx + Timers.Length - 1);
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
      }
      else  // Il componente è già stato inizializzato in precedenza... infilo i timer dove li ho messi l'ultima volta
      {
        // L'array di mio padre potrebbe essere più grande del mio se i componenti sono "dinamici" e vengono caricati in un 
        // ordine diverso da quello precedente (es: app->cmp1->cmp2 e poi, in una sessione differente app->cmp2->cmp1)
        Array.Resize(ref Dst.Timers, Math.Max(Timers.Length, Dst.Timers.Length));
        Array.Copy(Timers, MyTimerHandler.TIM_OFFSET + 1, Dst.Timers, MyTimerHandler.TIM_OFFSET + 1, Timers.Length - (MyTimerHandler.TIM_OFFSET + 1));
      }
      //
      // Se non l'ho ancora fatto shifto tutte le costanti contenute in MyGlb
      if (MyTimerHandler.TIM_OFFSET == 0)
      {
        // Il mio offset è il numero di timer di tutti i miei padri...
        // Per calcolarlo guardo a dove è finito il mio primo timer (l'elemento 0 è NULL)
        // Quello è l'offset dei miei timer rispetto all'array che contiene tutti i timer di tutti i componenti
        MyTimerHandler.TIM_OFFSET = Timers[1].Index - 1;
        //
        String tn = (MainFrm.CompNameSpace != null ? MainFrm.CompNameSpace + "." : "");
        FieldInfo[] props = Assembly.GetExecutingAssembly().GetType(tn + "MyGlb").GetFields();
        for (int j = 0; j < props.Length; j++)
        {
          FieldInfo p = props[j];
          if (p.Name.StartsWith("TIM_") || p.Name.Equals("MAX_TIMERS"))
            p.SetValue(null, ((int)p.GetValue(null)) + MyTimerHandler.TIM_OFFSET);
        }
      }
    }
  }
}
