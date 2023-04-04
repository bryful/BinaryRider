# BinaryRider

バイナリーエディタです。<br>
Stirlingを長く愛用していました。UTF-8に対応していないことがネックでかわりを探していましたが、見つからないので作り始めたのがこれです。<br>
<br>
作成中なので仕様が全然固まっていませんが、以下の項目を目標としています。<br>

* コードレベルに簡単に機能追加できる。<br>まぁ自分向けなので^^;
* Roslyn(C#スクリプト対応)<br>スクリプトで簡単に機能追加。
* 2画面表示・マルチドキュメント<br>まぁ今時普通ですね。
* 比較機能<br>Stirlingと同様な機能。
* gzファイルの自動展開<br>snesのフリーズファイル対策です。
* MDIアプリっぽいスタイル。<br>全体を税御するMainFormとドキュメントフォームとフォームが2種類あります。
* 構造体表示のカスタム機能

普段バイナリエディタで僕が使ってる用途用ですね。<br>
スクリプト対応のおかげでかなり便利になる予定。でも、凄い危険な香りがします。セキュリティーオールが怖いです。

# Todo
やることリスト<br>
保存機能は最後にやります。<br>

* 比較機能の実装。Stirlingのパクリ
* 便利なスクリプトコマンドを考える
* スクリプトランチャーの実装
* アイコンの作成。
* gzファイルの自動展開と、保存。
* 表示開始アドレスの指定。内部的にはすでに実装してますが、バグ有りで後回し状態

# StructView
構造体表示機能です。UIで構造体表示をカスタムかできます。

# インストール
まだ完成していませんが、珍しくインストラーを作るつもりです。<br>
.NET6の単一ファイル化が旨く動いてくれないのでしょうがないのでインストラー作ることにしました。<br>
Delphi6みたいに簡単にネイティブアプリ作れる時代が懐かしいです。<br>

# 進捗
現在試しに作ってる程度で怖いので保存機能はわざと実装していません。

# スクリプト
RoslynでC#での制御が可能です。まだスクリプトファイルのランチャーは作っていないので使い勝手最悪です。

専用コマンドは現在以下の通り

* MainForom MainForom<br>MainForomそのもの
* int FormsCount<br>開いてるドキュメントフォームの総数。
* RiderForm[] Forms<br>開いてるドキュメントフォームの配列
* RiderForm? ThisForm<br>現在アクティブなドキュメントフォーム
* string FormNames()<br>開いてるドキュメントフォームのName配列
* void Alert(object? obj, string cap = "")<br>Alertダイアログ。変数を適当に文字列に変えて表示します。
* void WriteLine(object? o)<br>コンソールフォームへ出力。改行付き
* void Write(object? o)<br>コンソールフォームへ出力。
* void ClearScreen() or void Clr()<br>コンソールフォームの画面消去





## Dependency
Visual studio 2022 C#

## License
This software is released under the MIT License, see LICENSE

## Authors

bry-ful(Hiroshi Furuhashi)
twitter:[bryful](https://twitter.com/bryful)
Mail: bryful@gmail.com

