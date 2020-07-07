# ASP.NET アプリケーションを ASP.NET Core アプリケーションに移行する
[「KOSMISCH Monolith を使ってアプリケーションを解析する」](./docs/analyze-application-by-kosmisch-monolith.md)では、KOSMISCH Monolithを使用して既存のASP.NETアプリケーションの問題点を整理しました。  
続いては実際に **ASP.NET** から **ASP.NET Core** に移行する作業を行いましょう。

## ASP.NET Coreとは
.NETを使用して、最新のクラウドベースのWebアプリケーションを構築するための、新しいオープンソースおよびクロスプラットフォームフレームワークです。  
[ASP.NET Core の概要 | Microsoft Docs](https://docs.microsoft.com/ja-jp/aspnet/core/)

ASP.NET Coreで実装可能なアプリケーションは以下のとおりです。  
- Webアプリケーション(MVC, Razor Pages)
- Web API
- リモートプロシージャコール(gRPC)
- リアルタイムWeb(SignalR)
- Progressive Web Apps(Blazor)

---

## 1.準備
1. 自身のGitHubアカウントにフォークしたリポジトリのページを開く

2. リポジトリをクローンするためのURLをコピーする  
![copy-repository-url](./img/copy-repository-url.png)

3. コマンドを入力してリポジトリをクローンする  
`git clone (コピーしたURL)`

4. `Kosmisch.Sample.OnPremisesAspnetApp`ディレクトリを`Kosmisch.Sample.OnPremisesAspnetApp.Net47`にリネームする

5. `Kosmisch.Sample.OnPremisesAspnetApp.sln`ファイルを削除する

6. `packages`ディレクトリがあれば削除する

7. リポジトリのディレクトリをVisual Studio Codeで開く  
![open-vscode](./img/open-vscode.png)

---

## 2.プロジェクトを作成する
リポジトリのディレクトリにて下記のコマンドを実行します。  
この手順により ASP.NET Coreのソリューションファイルおよびプロジェクトを作成することができます。

```
dotnet new global.json --sdk-version 2.1.508
dotnet new mvc -o Kosmisch.Sample.OnPremisesAspnetApp
dotnet new sln -n Kosmisch.Sample.OnPremisesAspnetApp
dotnet sln Kosmisch.Sample.OnPremisesAspnetApp.sln add Kosmisch.Sample.OnPremisesAspnetApp/Kosmisch.Sample.OnPremisesAspnetApp.csproj
dotnet dev-certs https --trust
```

実行結果はこのようになります。

```
> dotnet new global.json --sdk-version 2.1.508
The template "global.json file" was created successfully.

> dotnet new mvc -o Kosmisch.Sample.OnPremisesAspnetApp
The template "ASP.NET Core Web App (Model-View-Controller)" was created successfully.
This template contains technologies from parties other than Microsoft, see https://aka.ms/aspnetcore-template-3pn-210 for details.

Processing post-creation actions...
Running 'dotnet restore' on Kosmisch.Sample.OnPremisesAspnetApp\Kosmisch.Sample.OnPremisesAspnetApp.csproj...
  Restoring packages for C:\src\kosmisch-sample-on-premises-aspnet-app\Kosmisch.Sample.OnPremisesAspnetApp\Kosmisch.Sample.OnPremisesAspnetApp.csproj...
  Generating MSBuild file C:\src\kosmisch-sample-on-premises-aspnet-app\Kosmisch.Sample.OnPremisesAspnetApp\obj\Kosmisch.Sample.OnPremisesAspnetApp.csproj.nuget.g.props.
  Generating MSBuild file C:\src\kosmisch-sample-on-premises-aspnet-app\Kosmisch.Sample.OnPremisesAspnetApp\obj\Kosmisch.Sample.OnPremisesAspnetApp.csproj.nuget.g.targets.
  Restore completed in 898.61 ms for C:\src\kosmisch-sample-on-premises-aspnet-app\Kosmisch.Sample.OnPremisesAspnetApp\Kosmisch.Sample.OnPremisesAspnetApp.csproj.

Restore succeeded.

> dotnet new sln -n Kosmisch.Sample.OnPremisesAspnetApp
The template "Solution File" was created successfully.

> dotnet sln Kosmisch.Sample.OnPremisesAspnetApp.sln add Kosmisch.Sample.OnPremisesAspnetApp/Kosmisch.Sample.OnPremisesAspnetApp.csproj
Project `Kosmisch.Sample.OnPremisesAspnetApp\Kosmisch.Sample.OnPremisesAspnetApp.csproj` added to the solution.

> dotnet dev-certs https --trust
Trusting the HTTPS development certificate was requested. A confirmation prompt will be displayed if the certificate was not previously trusted. Click yes on the prompt to trust the certificate.
A valid HTTPS certificate is already present.
```

`dotnet dev-certs https --trust`を実行した際に、次のようなプロンプトが表示された場合は「はい」または「Yes」をクリックします。  
![dev-certs](./img/dev-certs.png)

上記の手順を行うことで、ASP.NET CoreのHTTPS開発証明書をローカル環境にインストールすることができます。  
HTTPS開発証明書をインストールしない場合、プロジェクトを実行してブラウザでアクセスした際に信頼されていないページである旨のエラーが表示されます。  
![untrust-page](./img/untrust-page.png)

---

## 3.プロジェクトを実行する
現時点でのプロジェクトを実行するために `dotnet run` コマンドを入力しましょう。

```
cd Kosmisch.Sample.OnPremisesAspnetApp
dotnet run
```

実行結果はこのようになります。

```
> dotnet run
D:\tmp\kosmisch-sample-on-premises-aspnet-app\Kosmisch.Sample.OnPremisesAspnetApp\Properties\launchSettings.json からの起動設定を使用中...
info: Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager[0]
      User profile is available. Using 'C:\Users\alterbooth\AppData\Local\ASP.NET\DataProtection-Keys' as key repository and Windows DPAPI to encrypt keys at rest.
Hosting environment: Development
Content root path: D:\tmp\kosmisch-sample-on-premises-aspnet-app\Kosmisch.Sample.OnPremisesAspnetApp
Now listening on: https://localhost:5001
Now listening on: http://localhost:5000
Application started. Press Ctrl+C to shut down.
```

ブラウザを起動して `http://localhost:5000` にアクセスすると、初期テンプレートのWebページが表示されることが確認できます。  
(実行を停止するときは`Ctrl+C`を入力します)

![aspnetcore-default-page](./img/aspnetcore-default-page.png)

ASP.NETに比べて ASP.NET Coreのプロジェクトファイルは簡素化されました。  
既存のプロジェクトファイルの構成についての移行の必要性の有無は、KOSMISCH Monolithで把握することができます。

![monolith-report-csproj](./img/monolith-report-csproj.png)

現時点の `Kosmisch.Sample.OnPremisesAspnetApp.csproj` の構成は下記のようになります。

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>netcoreapp2.1</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.App" />
    <PackageReference Include="Microsoft.AspNetCore.Razor.Design" Version="2.1.2" PrivateAssets="All" />
  </ItemGroup>

</Project>
```

---

## 4.ライブラリを移行する
ASP.NET CoreではASP.NET同様、NuGetに公開されているライブラリを使用することができます。  
ライブラリによっては .NET Frameworkのみをターゲットとしているものもあり、ライブラリのバージョンアップや変更が必要となることがあります。  
ライブラリごとの移行の必要性の有無は、KOSMISCH Monolithで把握することができます。

![monolith-report-apiport](./img/monolith-report-apiport.png)

今回は下記のコマンドでプロジェクトにライブラリをインストールします。

```
dotnet add package Newtonsoft.Json --version 12.0.3
```

実行結果はこのようになります。

```
> dotnet add package Newtonsoft.Json --version 12.0.3
  Writing C:\Users\alterbooth\AppData\Local\Temp\tmpEBDF.tmp
info : パッケージ 'Newtonsoft.Json' の PackageReference をプロジェクト 'D:\tmp\kosmisch-sample-on-premises-aspnet-app\Kosmisch.Sample.OnPremisesAspnetApp\Kosmisch.Sample.OnPremisesAspnetApp.csproj' に追加しています。
log  : D:\tmp\kosmisch-sample-on-premises-aspnet-app\Kosmisch.Sample.OnPremisesAspnetApp\Kosmisch.Sample.OnPremisesAspnetApp.csproj のパッケージを復元しています...
info : パッケージ 'Newtonsoft.Json' は、プロジェクト 'D:\tmp\kosmisch-sample-on-premises-aspnet-app\Kosmisch.Sample.OnPremisesAspnetApp\Kosmisch.Sample.OnPremisesAspnetApp.csproj'  のすべての指定されたフレームワークとの互換性があります。
info : ファイル 'D:\tmp\kosmisch-sample-on-premises-aspnet-app\Kosmisch.Sample.OnPremisesAspnetApp\Kosmisch.Sample.OnPremisesAspnetApp.csproj' に追加されたパッケージ 'Newtonsoft.Json' バージョン '12.0.3' の PackageReference。
info : 復元をコミットしています...
info : ロック ファイルをディスクに書き込んでいます。パス: D:\tmp\kosmisch-sample-on-premises-aspnet-app\Kosmisch.Sample.OnPremisesAspnetApp\obj\project.assets.json
log  : D:\tmp\kosmisch-sample-on-premises-aspnet-app\Kosmisch.Sample.OnPremisesAspnetApp\Kosmisch.Sample.OnPremisesAspnetApp.csproj の復元が 2.36 sec で完了しました。
```

現時点の `Kosmisch.Sample.OnPremisesAspnetApp.csproj` の構成は下記のようになります。

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>netcoreapp2.1</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.App" />
    <PackageReference Include="Microsoft.AspNetCore.Razor.Design" Version="2.1.2" PrivateAssets="All" />
    <PackageReference Include="Newtonsoft.Json" Version="12.0.3" />
  </ItemGroup>

</Project>
```

---

## 5.モデルを移行する
Entity Framework Coreの形式に沿ったModelに移行するため、下記の通りファイルをコピーします。  
- `Kosmisch.Sample.OnPremisesAspnetApp.Net47/Data/MyContext.cs`
    - `Kosmisch.Sample.OnPremisesAspnetApp/Data` フォルダを作成しコピー
- `Kosmisch.Sample.OnPremisesAspnetApp.Net47/Models/User.cs`
    - `Kosmisch.Sample.OnPremisesAspnetApp/Models`にコピー

---

## 6.データベースの接続定義を移行する
`Kosmisch.Sample.OnPremisesAspnetApp/appsettings.Development.json`を下記のように変更します。（ここで追記するのは開発環境におけるローカルDBへの接続設定です）

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Debug",
      "System": "Information",
      "Microsoft": "Information"
    }
  },
  "ConnectionStrings": {
    "DatabaseConnectionString": "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=kosmisch-sample-on-premises-core; Integrated Security=True; MultipleActiveResultSets=True;"
  }
}
```

---

## 7.DbContextを移行し、DBマイグレーションを行う
### 7-1.MyContextを移行する
`Kosmisch.Sample.OnPremisesAspnetApp/Data/MyContext.cs`を下記のように変更します。

```csharp
using Microsoft.EntityFrameworkCore;

namespace Kosmisch.Sample.OnPremisesAspnetApp.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }
    }

    public DbSet<Kosmisch.Sample.OnPremisesAspnetApp.Models.User> Users { get; set; }
}
```

### 7-2.スタートアップに登録する
ASP.NETのアプリケーションでO/Rマッパーに[Entity Framework](https://docs.microsoft.com/ja-jp/ef/ef6/)を使用している場合、[Entity Framework Core](https://docs.microsoft.com/ja-jp/ef/core/)に移行することが推奨されています。

`Kosmisch.Sample.OnPremisesAspnetApp/Startup.cs`の冒頭に下記のコードを追加します。

```csharp
using Kosmisch.Sample.OnPremisesAspnetApp.Data;
using Microsoft.EntityFrameworkCore;
```

`Kosmisch.Sample.OnPremisesAspnetApp/Startup.cs`の`ConfigureServices`メソッドに下記のコードを追加します。

```csharp
services.AddDbContext<MyContext>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnectionString")));
```

### 7-3.マイグレーションコマンドを実行する
Entity Framework Core へ移行したので、改めてマイグレーションコマンドを実行します。

```
dotnet tool install --global dotnet-ef
dotnet ef migrations add Initial
dotnet ef database update
```

コマンド実行後、LocalDBに`kosmisch-sample-on-premises-core`が作成されます。

---

## 8.エントリーポイントやスタートアップを移行する
ASP.NETでは`Global.asax`というファイルがエントリーポイントとなり、ルートの定義、フィルターの登録、エリアの登録などを処理していました。  
ASP.NET Coreではエントリーポイントは`Program.cs`というファイルになります。  
また`Startup.cs`というファイルでルートの定義、フィルターの登録、エリアの登録などを処理します。

`Global.asax`から`Startup.cs`に移行する際の問題点については、KOSMISCH Monolithで把握することができます。

![monolith-report-global](./img/monolith-report-global.png)


### 8-1.フィルターを移行する
`Kosmisch.Sample.OnPremisesAspnetApp.Net47/Filters`をコピーして`Kosmisch.Sample.OnPremisesAspnetApp`に貼り付けます。  
`Kosmisch.Sample.OnPremisesAspnetApp/Filters/LogFilter.cs`を開き、ファイル冒頭のusing群を下記のように変更します。

```csharp
// 変更前
using System.Diagnostics;
using System.Web.Mvc;

// 変更後
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;
```

#### 8-2.フィルター読み込みを修正する
`Kosmisch.Sample.OnPremisesAspnetApp/Startup.cs`の`ConfigureServices`メソッドを下記のように変更します。

```csharp
public void ConfigureServices(IServiceCollection services)
{
    // 変更前のコード
    // services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

    // 変更後のコード
    services
        .AddMvc(options => options.Filters.Add(new Kosmisch.Sample.OnPremisesAspnetApp.Filters.LogFilter()))
        .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
}
```

#### 8-3.ルーティング設定をスタートアップに登録する
`Kosmisch.Sample.OnPremisesAspnetApp/Startup.cs`の`Configure`メソッドを下記のように変更します。

```csharp
// 変更前のコード
// app.UseMvc(routes =>
// {
//     routes.MapRoute(
//         name: "default",
//         template: "{controller=Home}/{action=Index}/{id?}");
// });

// 変更後のコード
app.UseMvc(routes =>
{
    routes.MapRoute(
        name: "default",
        template: "{controller=Users}/{action=Index}/{id?}");
});
```

---

## 9.コントローラーの移行
次にコントローラーの移行を行います。  
`Kosmisch.Sample.OnPremisesAspnetApp.Net47/Controllers/UsersController.cs`を`Kosmisch.Sample.OnPremisesAspnetApp/Controllers`にコピーして、変更を行います。  
主な変更ポイントは以下の通りです。
- usingから`System.Web.Mvc`と`System.Data.Entity`を削除
- usingに`Microsoft.AspNetCore.Mvc`と`Microsoft.EntityFrameworkCore`を追加
- 引数Bindの`Include = `を削除
- `new HttpStatusCodeResult(HttpStatusCode.BadRequest)`を`BadRequest()`に変更
- `HttpNotFound()`を`NotFound()`に変更

また、先程のレポートで指摘があった通り、ASP.NET CoreではMyContextをDIで初期化するためコンストラクタ引数で受け取るよう変更する必要があります。  
以上を踏まえ、下記のようにコードを変更します。

```csharp
using Kosmisch.Sample.OnPremisesAspnetApp.Data;
using Kosmisch.Sample.OnPremisesAspnetApp.Helpers;
using Kosmisch.Sample.OnPremisesAspnetApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace Kosmisch.Sample.OnPremisesAspnetApp.Controllers
{
    public class UsersController : Controller
    {
        private MyContext db;

        public UsersController(MyContext db)
        {
            this.db = db;
        }

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Name,Age,ProfileImageName")] User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            user.Id = Guid.NewGuid();
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Users/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id,Name,Age,ProfileImageName")] User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Users/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SendEmailSample()
        {
            EmailHelper.Send();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SaveUserDataSample()
        {
            // HttpContext.Server.MapPathが使えないので一旦コメントアウト
            // 後ほど、ファイルの保存先変更時に併せて変更します
            // var users = db.Users.ToList();
            // var json = JsonConvert.SerializeObject(users);
            // var path = HttpContext.Server.MapPath("~/temp/");
            // FileHelper.WriteJson(path, json);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
```

---

## 10.ビューの移行
次にページのUIを定義するビューの移行を行います。  
`Kosmisch.Sample.OnPremisesAspnetApp.Net47/Views/Users`をコピーして`Kosmisch.Sample.OnPremisesAspnetApp/Views`に貼り付けます。`Create.cshtml`と`Edit.cshtml`について、`@section Scripts`部分を削除します。  
以下、削除対象の箇所です。

```
@section Scripts {
    @Scripts.Render("~/bundles/jqueryval")
}
```

---

## 11.ファイル操作箇所の変更
パブリッククラウドのPaaS環境にホストするアプリケーションは、スケールアウトを想定してステートレス構成で実装することが推奨されています。  
今回はファイルの保存先をローカルからAzure Blob Storageに変更し、サーバー内に画像を保管しないコードに変更します。

```csharp
public static class FileHelper
{
    public static void WriteJson(string json)
    {
        var connectionString = Environment.GetEnvironmentVariable("StorageConnectionString") ?? "UseDevelopmentStorage=true";
        CloudStorageAccount.TryParse(connectionString, out var storageAccount);

        var cloudBlobClient = storageAccount.CreateCloudBlobClient();
        var containerName = Environment.GetEnvironmentVariable("BlobContainerName") ?? "mycontainer";
        var cloudBlobContainer = cloudBlobClient.GetContainerReference(containerName);
        cloudBlobContainer.CreateAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        var permissions = cloudBlobContainer.GetPermissionsAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        permissions.PublicAccess = BlobContainerPublicAccessType.Blob;
        cloudBlobContainer.SetPermissionsAsync(permissions).ConfigureAwait(false).GetAwaiter().GetResult();

        var cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference($"sample-data-{DateTime.Now.ToString("yyyyMMddHHmmss")}.json");
        cloudBlockBlob.UploadTextAsync(json).ConfigureAwait(false).GetAwaiter().GetResult();
    }
}
```

UsersController内の`SaveUserDataSample()`を以下の通り変更します。

```csharp
[HttpPost]
public ActionResult SaveUserDataSample()
{
    var users = db.Users.ToList();
    var json = JsonConvert.SerializeObject(users);
    FileHelper.WriteJson(json);
    return RedirectToAction("Index");
}
```

---

## 12.メール送信処理の変更
クラウドサービスでは、IaaSなどから直接メールを送信することが制限されており、自身で構築したMTAでメールを送信することは出来ません。  
そのため、メールを送信する場合には専用のSaaSを利用してメールを送信することが推奨されています。  
今回は[SendGrid](https://sendgrid.kke.co.jp/)を用いたメール送信を行うコードに変更します。

```csharp
using SendGrid;
using SendGrid.Helpers.Mail;
using System;

namespace Kosmisch.Sample.OnPremisesAspnetApp.Helpers
{
    /// <summary>
    /// メール送信用ヘルパークラス
    /// </summary>
    public static class EmailHelper
    {
        /// <summary>
        /// メールを送信する
        /// </summary>
        /// <param name="body">bodyテキスト</param>
        public static void Send(string body)
        {
            var from = new EmailAddress()
            {
                Name = "Kosmisch",
                Email = "from@kosmischsample.net"
            };
            var to = new EmailAddress()
            {
                Name = "Test",
                Email = "to@kosmischsample.net"
            };
            var subject = "Kosmisch Sample";
            var message = MailHelper.CreateSingleEmail(from, to, subject, body, body);

            var apiKey = Environment.GetEnvironmentVariable("SendGridApiKey");
            var client = new SendGridClient(apiKey);
            var response = client.SendEmailAsync(message).ConfigureAwait(false).GetAwaiter().GetResult();
        }
    }
}
```

---

## 13.古いアプリケーションを削除する
`Kosmisch.Sample.OnPremisesAspnetApp.Net47`ディレクトリを削除しましょう。

---

## 14.修正内容をリポジトリに反映する
ASP.NETで実装していたアプリケーションを ASP.NET Coreに移行することができました。  
リポジトリディレクトリにて下記のコマンドを入力して、ここまでの変更をリポジトリに反映しましょう。

```shell
git add .
git commit -m "ASP.NET Coreに移行した"
git push origin master
```

---

## 15.KOSMISCH Monolithで再度解析を行う
[「#2 KOSMISCH Monolith を使ってアプリケーションを解析する」](./analyze-application-by-kosmisch-monolith.md)と同じ手順で、KOSMISCH Monolithを使用して ASP.NET Coreのソースコードを再度解析しましょう。  
- [KOSMISCH Monolith](https://monolith.kosmisch.tech)にログインする
- 自身のGitHubリポジトリを指定して解析を開始する
- 解析が終了したらレポートを確認する
