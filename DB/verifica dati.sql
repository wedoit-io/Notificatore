-- 1° query utilizzata dentro le  procedure che inviano la notifica per iOS, Android, ...
-- ciclo per ogni applicazione che ha spedizioni da inviare
select distinct
  A.ID_APPLICAZIONE as MIDAPPLICAZI
from
  SPEDIZIONI A,
  APPS_PUSH_SETTING B,
  APPS C
where B.ID = A.ID_APPLICAZIONE
and   C.ID = B.ID_APP
and   (A.TYPE_OS = '2') -- 1 = iOS ; 2 = Android
and   (B.FLG_ATTIVA = 'S')
and   ((A.FLG_STATO = 'W' AND (A.ID = null OR (null IS NULL))) OR (A.ID = null AND C.FLG_INVIO_IMMEDIATO = 'S' AND A.FLG_STATO = 'P'))

-- 2° 
-- prendo alcuni dati dell'app
select * from APPS_PUSH_SETTING A
where a.ID = 98
and A.FLG_ATTIVA = 'S'

-- 3°
-- per ogni spedizione da inviare dell'applicazione
select
A.ID as ID,
REPLACE(A.REG_ID, ' ', '') as RREGID,
A.ID_APPLICAZIONE as RIDAPPLICAZI,
A.DES_MESSAGGIO as RMESSAGGIO,
A.CUSTOM_FIELD1 as CUSTFIEL1SPE,
A.CUSTOM_FIELD2 as CUSTFIEL2SPE,
REPLACE(A.DEV_TOKEN, ' ', '') as DEVITOKESPED
from
SPEDIZIONI A,
APPS_PUSH_SETTING B,
APPS C
where B.ID = A.ID_APPLICAZIONE
and   C.ID = B.ID_APP
and   (A.ID_APPLICAZIONE = 98)
and   ((A.DAT_ELAB IS NULL) OR CONVERT (float, GETDATE() - A.DAT_ELAB) > 0.100)
and   ((A.FLG_STATO = 'W' AND (A.ID = 20806422 OR (20806422 IS NULL))) OR (A.ID = 20806422 AND C.FLG_INVIO_IMMEDIATO = 'S' AND A.FLG_STATO = 'P'))

