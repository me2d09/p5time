# P5Time – WinForms aplikace pro zadávání výsledků

Starší desktopová aplikace pro průběžné zadávání výsledků závodů do MySQL. Hlavní okno umí udržovat spojení s DB a během závodu zapisovat starty, cíle, penalizace, výsledky a generovat výsledkovky.

## Technologie / runtime
- .NET Framework **3.5** (WinForms) – viz `P5Time.csproj` (`<TargetFrameworkVersion>v3.5</TargetFrameworkVersion>`)
- Visual Studio 2010 (Solution Format 11.00) – viz `P5Time.sln`
- MySQL konektor **MySql.Data** (v manifestech je **5.2.1.0**)
- Export do XLSX přes **ExcelPackage/EPPlus** (přibalené ve `library\excelpackage`)

## Struktura projektu (rychlý přehled)
- `Form1.cs` – **hlavní okno** aplikace; většina logiky, napojení na DB, taby (číselníky, posádky, rozlosování, startovka, výsledky, výsledkovka, …)
- `Form2.cs` – **nastavení**: server/uživatel/heslo/DB, AutoStart, cesta k Excel šabloně, cesta k `mysqldump.exe`
- `ExportExcel.cs` – export výsledků do XLSX podle šablony (ExcelPackage)
- `PrintDGV.cs`, `PrintOptions.cs` – tisk/preview DataGridView
- `registry.cs` – třída `Common`: ukládání nastavení do registru (HKCU)
- `maskedtextbox*.cs`, `NumericTextBoxColumn.cs`, `PenaltyTextBoxColumn.cs` – vlastní DataGridView sloupce
- `p5time_svazvodaku_czDataSet*.xsd` – typed DataSety pro číselníky
- `Resources/`, `*.resx` – obrázky a lokalizované zdroje
- `template.xlsx`, `template2.xlsx` – šablony exportu

## Konfigurace připojení (MySQL)
- `app.config` obsahuje connection string **P5Time.Properties.Settings.conn**.
- Pozor: v repu je uložené **heslo** – doporučuji ho změnit a v reálném provozu necommitovat reálné údaje.

### Ukládání nastavení do registru
Aplikace ukládá některá nastavení do **HKCU\Software\SVoCR\P5Time**:
- `Server`, `UserId`, `Password`, `Database`
- `AutoStart`
- `ExcelTemplate`
- `MysqldumpPath`
- `LastUsedPohar`, `LastZavod`, `LastTab`

## Build / spuštění
1. Otevři `P5Time.sln` ve Visual Studiu (ideálně 2010+, s podporou .NET Framework 3.5).
2. Zkontroluj dostupnost **MySql.Data.dll** (v projektu je reference na `bin\MySQL.Data.dll`).
3. Projekt má reference na **ExcelPackage** v repu (`library\excelpackage\src\ExcelPackage.csproj`).
4. Nastav připojení k DB buď v `app.config`, nebo v GUI (Form2).
5. Spusť projekt (entry point je `Form1.Main`).

## Očekávání na databázi (z kódu)
Aplikace volá např.:
- stored procedures: `ins_start_time`, `ins_end_time`, `sp_vysledky_zavodu`, `sp_vysledky_diplomy`, `up_tr_prepocitej_vysledky`, `up_uzavreni_vysledku`, `sp_set_clean`
- tabulky: `cis_poharu`, `zavod`, `discipliny_zavodu`, `posadky_zavodu`, `posadky_discipliny`, `zavodnici_*`, `cis_*` …

## DB schéma (odhad podle kódu)
Pozn.: schéma je odvozené z SQL dotazů ve `Form1.cs`, přesné sloupce nejsou v repu.

### Základní entity a vazby
- `cis_poharu` – seznam pohárů/sezón (`id_poharu`, `nazev`, `rok`).
- `zavod` – závody v sezóně, vazba na `cis_poharu` přes `id_poharu` (a používá se `dirty` pro stav/uzamčení).
- `discipliny_zavodu` – disciplíny přidělené k závodu (`id_zavodu`, `id_discipliny`).
- `cis_disciplin` – číselník disciplín (napojeno v UI).
- `cis_kategorii` – číselník kategorií.
- `cis_statusy` – číselník statusů výsledku (DNF, DSQ, apod.).
- `vkluby` / `cis_klubu` – číselník klubů (v kódu se používají oba názvy, `vkluby` v UI, `cis_klubu` v exportu).
- `vosoby`, `vosoby2` – seznam osob (použito pro joiny ve startovce/výsledcích).
- `cis_osob` – tabulka pro vkládání nových osob (insert při přidání závodníka).
- `poharove_posadky` – posádky pro pohár, vazba na `cis_poharu`, `cis_kategorii`, `cis_klubu`.
- `zavodnici_poharu` – vazba posádka–závodník v rámci poháru.
- `posadky_zavodu` – posádky v konkrétním závodě (`id_zavodu`, `id_kat`, `id_klubu`, `startovni_cislo`, `nazev`).
- `posadky_discipliny` – posádka × disciplína v závodě (`id_posadky_zavodu`, `id_discipliny`).
- `zavodnici_discipliny` – závodníci v posádce/disciplině (`id_posadky_discipliny`, `id_zavodnika`).
- `prubezne_vysledky` – průběžné časy/penalty/statusy (join na `posadky_discipliny`).
- `uzavrene_vysledky` – příznaky schválení výsledků (přes `id_posadky_discipliny`).
- DB funkce: v selectech je `timefromint(...)` – převod času z int na text.

### Používané stored procedures
- `up_posadka_zavodu_ins` – založení posádky do závodu (voláno pro každou disciplínu).
- `up_posadka_poharu_ins` – založení posádky do poháru.
- `ins_start_time` – zápis startovních časů.
- `ins_end_time` – zápis cílových časů + penalty + statusy.
- `up_tr_prepocitej_vysledky` – přepočet výsledků po změně.
- `sp_vysledky_zavodu` – vygenerování výsledkovky závodu.
- `sp_vysledky_diplomy` – data pro diplomy.
- `up_uzavreni_vysledku` – uzavření výsledků pro disciplínu/kategorii.
- `sp_set_clean` – vynulování `dirty` příznaků po exportu.

## Flow aplikace (z pohledu DB)
1. **Start aplikace**: načtení číselníků `cis_statusy` a `cis_kategorii`.
2. **Připojení k DB**: otevření `MySqlConnection`, načtení `cis_disciplin`, `vkluby`, `vosoby`.
3. **Volba sezóny**: `cis_poharu` → načtení závodů v sezóně (`zavod`) + disciplín závodu (`discipliny_zavodu`).
4. **Posádky**:
   - Vytvoření nové posádky přes `up_posadka_zavodu_ins` (+ vazby na disciplíny).
   - Vytvoření pohárové posádky přes `up_posadka_poharu_ins`.
   - Napojení závodníků přes `zavodnici_discipliny` / `zavodnici_poharu`.
5. **Rozlosování**: přidělení `startovni_cislo` do `posadky_zavodu`.
6. **Startovka**: čtení z `prubezne_vysledky` + zápis startů přes `ins_start_time`.
7. **Výsledky**: čtení z `prubezne_vysledky`, zápis časů/penalt přes `ins_end_time`, přepočet přes `up_tr_prepocitej_vysledky`.
8. **Výsledkovka**: generování přes `sp_vysledky_zavodu`, schválení přes `up_uzavreni_vysledku` / `uzavrene_vysledky`.
9. **Export**:
   - XLSX přes `ExportExcel` (šablona + data z výsledkovky).
   - `mysqldump` pro tabulky s `dirty=1`, poté `sp_set_clean`.
   - Volitelný upload přes HTTP POST na `svazvodaku.cz/import.php`.
