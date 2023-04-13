
-- *** IMPOSTAZIONI ***
select imp.FLG_DEBUG, imp.*
from IMPOSTAZIONI imp

-- *** LOGS ***
-- FLG_LEV_DEBUG = 0 (SPENTO)
-- FLG_LEV_DEBUG = 1 (ERRORI)
-- FLG_LEV_DEBUG = 0 (TRACE)
-- FLG_LEV_DEBUG = 0 (SERVER SESSION)
select *
from LOGS
where 1=1
and data_log >= '20220513 12:20:00'
--and data_log >= getdate() -1 
--and FLG_LEV_DEBUG = 1
--and testo not like '%Certificate%'
order by ID DESC

SELECT *
From SPEDIZIONI spe
WHERE FLG_STATO = 'S'
ORDER BY DAT_CREAZ

-- per ogni giorno, restituisce il numero di device scaricati nel giorno e numero utenti che hanno fatto l'accesso in quel giorno
-- ma che non hanno fatto l'accesso in giorni successivi
select data,
       sum(numero_utenti_scar) as numero_utenti_scar,
       sum(numero_utenti_ult_accesso) as numero_utenti_ult_accesso
from v_neth_data_stat
group by data, anno, mese, giorno
order by anno desc, mese desc, giorno desc

select [des_utente], [ios], [android], 
       FORMAT([data_creazione], N'dd/MM/yyyy HH:mm'),
       FORMAT([data_accesso], N'dd/MM/yyyy HH:mm')
from v_neth_utenti
order by [data_accesso] desc


select year(DAT_ELAB) as anno,
       month(DAT_ELAB) as mese,
       day(DAT_ELAB) as giorno,
       count(*)
from spedizioni
where DAT_ELAB is not null
group by year(DAT_ELAB),
         month(DAT_ELAB),
         day(DAT_ELAB)
order by year(DAT_ELAB),
         month(DAT_ELAB),
         day(DAT_ELAB)

select SUBSTRING(des_utente, CHARINDEX('@', DES_UTENTE ) + 1, 100), 
       count(*) as num_utenti, 
       FORMAT(min(data_accesso), N'dd/MM/yyyy HH:mm') as primo_accesso,
       FORMAT(max(data_accesso), N'dd/MM/yyyy HH:mm') as ultimo_accesso
from v_neth_utenti
group by SUBSTRING(des_utente, CHARINDEX('@', DES_UTENTE ) + 1, 100)
order by count(*) desc

select *
from logs
order by id desc


-- **********************************
select distinct   A.ID_APPLICAZIONE as MIDAPPLICAZI 
from   SPEDIZIONI A,   APPS_PUSH_SETTING B 
where B.ID = A.ID_APPLICAZIONE and   (A.TYPE_OS = '2') and   (B.FLG_ATTIVA = 'S') 
and   (((A.FLG_STATO = 'W') AND (ISNULL(A.TYPE_MESSAGE, 1) = 1) 
AND (A.ID = NULL OR (NULL IS NULL))) OR ((A.FLG_STATO = 'P') 
AND (ISNULL(A.TYPE_MESSAGE, 1) = 2) AND (A.ID = NULL)))

select distinct   A.ID_APPLICAZIONE as MIDAPPLICAZI 
from   SPEDIZIONI A,   APPS_PUSH_SETTING B 
where B.ID = A.ID_APPLICAZIONE and   (A.TYPE_OS = '1') and   (B.FLG_ATTIVA = 'S') 
and   (((A.FLG_STATO = 'W') AND (ISNULL(A.TYPE_MESSAGE, 1) = 1) 
AND (A.ID = NULL OR (NULL IS NULL))) OR ((A.FLG_STATO = 'P') 
AND (ISNULL(A.TYPE_MESSAGE, 1) = 2) AND (A.ID = NULL)))

select distinct   A.ID_APPLICAZIONE as MIDAPPLICAZI,   A.TENTATIVI as NUMETENTSPED 
from   SPEDIZIONI A,   APPS_PUSH_SETTING B 
where B.ID = A.ID_APPLICAZIONE and   (A.TYPE_OS = '3') and   (B.FLG_ATTIVA = 'S') 
and   ((A.FLG_STATO = 'W' AND (A.ID = NULL OR (NULL IS NULL))) 
OR (A.ID = NULL AND ISNULL(A.TYPE_MESSAGE, 1) = 2 AND A.FLG_STATO = 'P'))

select *
from APPS_PUSH_SETTING 
where 1=1

and TYPE_OS = '3'


*****************






-- *** NUMERO SPEDIZIONI PER TIPO DISPOSITIVO ***
select 
  CASE 
	WHEN (spe.TYPE_OS = 1) THEN 'iOS'
	WHEN (spe.TYPE_OS = 2) THEN 'ANDROID'
	ELSE 'APP SCONOSCIUTA!'
  END  as TYPOS_DES,
   CASE 
	WHEN (spe.flg_stato = 'W') THEN 'IN ATTESA'
	WHEN (spe.flg_stato = 'E') THEN 'ERRORE'
	WHEN (spe.flg_stato = 'S') THEN 'INVIATO'
	WHEN (spe.flg_stato = 'P') THEN 'IN CORSO'
	ELSE 'APP SCONOSCIUTA!'
  END  as TYPOS_DES,
  count(*) as NumSpedizioni
from SPEDIZIONI spe
where 1=1
and  spe.dat_creaz >= '20220901 00:00:00'
and  spe.dat_creaz <= '20220901 23:59:59'
--and  spe.dat_creaz >= getdate() -1 --'20220221 00:00:00'
group by spe.TYPE_OS,spe.flg_stato
;

-- *** SPEDIZIONI ***
-- flg_stato = 'W' (attesa) 'E' (errore) 'S' (inviato) 'P' (in corso)
-- TYPE_OS = 1 (iOS) 2 (Android)
select spe.TYPE_OS, spe.flg_stato, spe.INFO, spe.*
--count(*)
from SPEDIZIONI spe
where 1=1
--and  spe.dat_creaz <= /*getdate()*/ '20210929 17:12:00'
--and  spe.dat_creaz <= getdate() - 1
and spe.flg_stato = 'W'
--and spe.TYPE_OS = 2
--and id in (30851863)
--and lower(spe.INFO) like 'api - onnotificationfailed%'
order by spe.id desc
;

 -- *** DEVICE TOKEN ***
-- TYPE_OS -> 1=iOS 2=Android
select *
from
  DEV_TOKENS A
where 1=1
and   (A.FLG_ATTIVO = 'N') OR (A.FLG_RIMOSSO = 'S')
--and DEV_TOKEN = '0c6b975ba7d84fda7ed74d779d86377af7ac2614ae2994a67fa9d95db835d5f3'
--and TYPE_OS = 1
--and   (A.DES_UTENTE = '3121872')
--and (A.ID_APPLICAZIONE in (86,88,89,90))
--and DATA_ULT_ACCESSO < '20210101 00:00:00' 
order by DATA_ULT_ACCESSO desc
;


/* DEVICE TOKEN PER UTENTE */
select des_utente, count(*) as num
from
  DEV_TOKENS A
where 1=1
--and (A.ID_APPLICAZIONE in (86,88,89,90))
and   (A.FLG_ATTIVO = 'S')
and   (A.FLG_RIMOSSO = 'N')
and   (A.DES_UTENTE = '3121872')
group by des_utente
having count(*) > 10
order by num desc
;


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



-- ************************** PULIZIA DATI **************************

-- CANCELLO I DEVICE TOKEN VALIDI CON ULTIMO ACCESSO PRECEDENTE AD UNA CERTA DATA
-- tot 253425
-- da canc -> 180593
-- rimanent -> 72832
select * --delete
from  DEV_TOKENS
where 1=1
and DATA_ULT_ACCESSO < '20201001 00:00:00' 
--and   (FLG_ATTIVO = 'S')
--and   (FLG_RIMOSSO = 'N')
--and TYPE_OS = 1
order by DATA_ULT_ACCESSO desc
;

-- 44590
select count(*)
from SPEDIZIONI spe
where 1=1
--and spe.dat_creaz <= '20211001 00:00:00'
--and spe.dat_creaz <= '20211001 11:40:00'
and spe.flg_stato = 'W'
--and spe.TYPE_OS = 2
--order by spe.dat_creaz desc

-- 44523
/*
-- metto lo stato inesistente X a quelle in attesa (W) per non farle considerare al notificatore e inviarle un po alla volta in caso di problemi
update SPEDIZIONI
set flg_stato = 'X'
where 1=1
--and dat_creaz <= getdate()  -- '20210926 00:00:00'
--and dat_creaz <= getdate() - 1
and dat_creaz >= '20210929 00:00:00'
and flg_stato = 'W'
--and TYPE_OS = 1
*/

/*
-- metto in attesa (W) quelle in stato inesistente (X) per inviarle un po alla volta in caso di problemi
update SPEDIZIONI 
set flg_stato = 'W'
where 1=1
--and spe.dat_creaz <= '20211001 00:00:00'
--and dat_creaz <= '20211001 11:40:00'
and flg_stato = 'X'
--and TYPE_OS = 2
*/

/*
delete from SPEDIZIONI
where 1=1
and  dat_creaz >= '20210318'
and flg_stato = 'W'
*/