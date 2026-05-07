Udført af Jwan Sidou

Dette projekt er en webapplikation udviklet i ASP.NET C#. Valget af teknologien og sproget er baseret på et ønske om,
som studerende at gå i dybden med C#-sproget og styrke mine kompetencer inden for backend udvikling.

Projektets primære formål er at overvåge fugtighedsniveauer i den tyske by Satemin i forskellige dybder af jorden.
Systemer bør fortage automatiserede API-kald for at hente data om fugtigheden.

Hvis fugtighedsniveauet falder under en fastsat grænseværdi, i den specifikke dybe, sender systemet en besked til en ekstern operatør, som vil sørge for at planten eller træet skal vandes.

Projektet fokuserer specifikt på den cyber-fysiske del:

•	API integration, håndtering af kald og behandling af data.
•	Historik, lagring af alle tidligere kald og målinger for at følge udvikling.
•	Arkitektur, implementering af relevante designmønstre for at sikre en skalerbar og vedligeholdelsesvenlig kodebase.

Derudover vil jeg udarbejde følgende i designfasen:

•	Kravliste, som vil specificere, systemets funktionaliteter.
•	UML-diagram, visualisering af systemets arkitektur og klasse struktur.
•	Design mønstre, løbende overvejelse om hvilket/hvilke design mønster man skal bruge.

https://open-meteo.com/en/docs/dwd-api?hourly=soil_moisture_0_to_1cm,soil_moisture_9_to_27cm,soil_moisture_27_to_81cm&latitude=52.9566&longitude=11.0949&forecast_days=1&past_days=7

--- Sådan køres projektet --- 

Få de nødvendige pakker til køre projektet: "dotnet restore"
Med det command får du:
- Microsoft.EntityFrameworkCore 9.0
- Microsoft.EntityFrameworkCore.Design 9.0
- Npgsql.EntityFrameworkCore.PostgreSQL 9.0
- Plotly.Blazor 7.1.0

1. Klon projektet: "git clone https://github.com/JwSid24/Soil"
2. Installér pakker: "dotnet restore"
3. Start databasen: "docker compose up -d"
4. Installér EF Core værktøj: "dotnet tool install --global dotnet-ef"
5. Kør migration: "dotnet ef database update"
6. Start appen: "dotnet run"
7. Åben i browser på localhost.
