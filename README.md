# kosmisch-sample-on-premises-aspnet-app
## 概要
あなたは情報システム部に所属していて、社内システムを運用しています。
その社内システムは ASP.NET のアプリケーションで、実行環境にオンプレミスのサーバーにインストールしたWindows Server 2008 R2を使っています。
オペレーティングシステムのサポート終了への対応や、サーバハードウェアの故障対応や更新の手間を省力化してメンテナンス性を向上させることを考え、近々実行基盤をクラウドへ移行したいと考えています。

このサンプルでは、 ASP.NET アプリケーションを Microsoft Azure の PaaS 環境で実行する ASP.NET Core アプリケーションに移行する手順を解説し、上記のような状況でKOSMISCHがどのように利用できるかを理解します。

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
