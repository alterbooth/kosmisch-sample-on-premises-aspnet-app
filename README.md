# kosmisch-sample-on-premises-aspnet-app
## 概要
例えば、あなたは情報システム部に所属していて、社内システムを運用しているとします。
その社内システムは ASP.NET のアプリケーションで、実行環境にWindows Server 2008 RCを使っています。
そこで、サポート終了やメンテナンス性の向上も考え、近々クラウドへ移行したいと考えているとします。

このサンプルでは、そのような課題を解決すべく、後述する機能を持った ASP.NET アプリケーションを Microsoft Azure の PaaS 環境で実行する ASP.NET Core アプリケーションに移行する手順を解説します。

## 解析手順
[「KOSMISCH Monolith を使ってアプリケーションを解析する」](./docs/analyze-application-by-kosmisch-monolith.md)

## 移行手順
[「ASP.NET アプリケーションを ASP.NET Core アプリケーションに移行する」](./docs/migrate-aspnet-to-aspnetcore.md)

## 実施環境
本サンプルは下記のツールやアカウントを用意した上で実施することを推奨します。

### Visual Studio Code
https://code.visualstudio.com/

### .NET Core 2.1 SDK
https://dotnet.microsoft.com/download/dotnet-core/2.1

### Docker
Windows https://docs.docker.com/docker-for-windows/
Mac https://docs.docker.com/docker-for-mac/

### Git
https://git-scm.com/

### GitHubアカウント
https://github.com/

### SQL Server Express LocalDB
https://docs.microsoft.com/ja-jp/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver15

### Azure Storage Emulator
https://docs.microsoft.com/ja-jp/azure/storage/common/storage-use-emulator
