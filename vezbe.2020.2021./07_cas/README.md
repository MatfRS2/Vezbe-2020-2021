# Вежбе -- Седми час -- Identity и ауторизација, коришћење SignalR 

[повратак](../../README.md)

**Наставак унапређивања и додавања нових функционалности интернет продавници.**

## Задатак: Изменити права приступа

- За рад са корисницима користимо ASP.NET Core библиотеку Identity у којој је већ имплеметирано већина својстава који су најчешће потребни у апликацији. Више о разним могућностима које нуди у званичној [документацији](https://docs.microsoft.com/en-us/aspnet/identity/) (two-factor authentication, password recovery...).
- Наредбе за додавање Identity базе:
	- `dotnet ef migrations add Initial --contex AppIdentityDbContext`
	- `dotnet ef database update --context AppIdentityDbContext`
- Креирати `AccountController`, `Views/Account/Korisnici.cshtml`, `Views/Account/KreirajKorisnika.cshtml`, `Models/ViewModels/KreirajKorisnikaModel.cs`
- Роле ћемо додати експлицитно у базу. То је могуће урадити на два начина, преко упита или директно из апликације. Овог пута је одабран други начин (погледати `IdentitySeedData`).
- На разна места (код разних контролера и њихових метода) додати:
    - [Authorize (Roles = "Administrator")]
    - [Authorize (Roles = "Administrator, ObicanKorisnik")]
    - [AllowAnonymous] 
    - итд.

## Задатак: Додати могућност четовања за кориснике 

- Додавање SignalR пакета пројекту:
	- `Add > Client-Side Library`
	- Изабрати `unpkg` и куцати `aspnet/signalr` (сам би требало да пронађе одговарајући пакет), потом `Install`
	- Ако је успешно инсталирано, у фолдеру `wwwroot/lib` би требало да се налази фолдер `signalr` (у коме се налазе жељене скрипте)

- Креирати фолдер `Hubs` и у њему класу `CetHub`
- Додати потребна подешавања у класу `Startup`
- У `AdminController` додати метод `Cetovanje`
- Креирати `Views/Admin/Cetovanje.cshtml`. Битна су последња два реда где се наводе скрипте које се користе. Једна скрипта је део пакета `SignalR`, а другу пишемо ми и ту задајемо какво понашање желимо.
- Креирати `wwwroot/lib/signalr/chat.js`

 

[повратак](../../README.md)