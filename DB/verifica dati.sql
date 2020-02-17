-- elenco spedizioni
select * from SPEDIZIONI
order by id desc;

-- WEB API -> SEND PUSH
-- 1. verifico l'esistenza dell'app
select
  A.ID as ID
from
  APPS A
where (A.AUTH_KEY = '1b07390a-1b39-4a57-8268-554d47770041')
and   (A.APP_KEY = 'YOUATB');

-- 2. per ogni impostazione dell'app (iOS, Android, etc.)
select
  A.ID as ID,
  A.TYPE_OS as TYPOS_CODE,
  CASE 
	WHEN (A.TYPE_OS = 1) THEN 'iOS'
	WHEN (A.TYPE_OS = 2) THEN 'ANDROID'
	WHEN (A.TYPE_OS = 3) THEN 'Windows Phone'
	WHEN (A.TYPE_OS = 5) THEN 'Windows Store'
	ELSE 'APP SCONOSCIUTA!'
  END  as TYPOS_DES,
  A.WNS_XML as WNXMTEAPPUSE
from
  APPS_PUSH_SETTING A
where (A.ID_APP = '74')
and   (A.FLG_ATTIVA = 'S')
;

-- 3. per ogni Device dell'impostazione sopra
select
  A.DEV_TOKEN as DEVTOKDEVTOK,
  A.REG_ID as REGIDEVITOKE,
  A.TYPE_OS as TYPOS_CODE,
  CASE 
	WHEN (A.TYPE_OS = 1) THEN 'iOS'
	WHEN (A.TYPE_OS = 2) THEN 'ANDROID'
	WHEN (A.TYPE_OS = 3) THEN 'Windows Phone'
	WHEN (A.TYPE_OS = 5) THEN 'Windows Store'
	ELSE 'APP SCONOSCIUTA!'
  END  as TYPOS_DES,
  A.DES_UTENTE as UTENDEVITOKE
from
  DEV_TOKENS A
where (A.ID_APPLICAZIONE in (86,88,89,90))
and   (A.FLG_ATTIVO = 'S')
and   (A.FLG_RIMOSSO = 'N')
and   (A.DES_UTENTE = '3000007')


-- 1° query utilizzata dentro le  procedure che inviano la notifica per iOS, Android, ...
-- ciclo per ogni applicazione che ha spedizioni da inviare
select distinct
  A.ID_APPLICAZIONE as MIDAPPLICAZI
from
  SPEDIZIONI A,
  APPS_PUSH_SETTING B
where B.ID = A.ID_APPLICAZIONE
and   (A.TYPE_OS = '1') -- 1 = iOS ; 2 = Android
and   (B.FLG_ATTIVA = 'S')
and   ((A.FLG_STATO = 'W' AND (A.ID = 20806457 OR (20806457 IS NULL))) OR (A.ID = 20806457 AND ISNULL(A.TYPE_MESSAGE, 1) = '2' AND A.FLG_STATO = 'P'))



-- 2° 
-- prendo alcuni dati dell'app
select * from APPS_PUSH_SETTING A
where a.ID = 86 -- è l'id sopra
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
REPLACE(A.DEV_TOKEN, ' ', '') as DEVITOKESPED,
A.FLG_STATO,
A.TYPE_MESSAGE,
CONVERT (float, GETDATE() - A.DAT_ELAB)
from
SPEDIZIONI A,
APPS_PUSH_SETTING B
where B.ID = A.ID_APPLICAZIONE
and   (A.ID_APPLICAZIONE = 86)
and   (LEN(A.DEV_TOKEN) = 64)
and   ((A.DAT_ELAB IS NULL) OR CONVERT (float, GETDATE() - A.DAT_ELAB) > 0.100)
and   ((A.FLG_STATO = 'W' AND (A.ID = 20806457 OR (20806457 IS NULL))) OR (A.ID = 20806457 AND ISNULL(A.TYPE_MESSAGE, 1) = '2'  AND A.FLG_STATO = 'P'))
order by id desc

