using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookManagement.Objects
{
    class Customer
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        //名前
        public string Name { get; set; }
        //電話番号
        public string Phone { get; set; }


        //書籍タイトル
        public string title { get; set; }
        //書籍タイトルカナ
        public string titleKana { get; set; }
        //書籍サブタイトル
        public string subTitle { get; set; }
        //書籍サブタイトルカナ
        public string subTitleKana { get; set; }
        //叢書名（シリーズ名）
        public string seriesName { get; set; }
        //叢書名カナ
        public string seriesNameKana { get; set; }
        //多巻物収録内容
        public string contents { get; set; }

        //著者名
        public string author { get; set; }
        //著者名カナ
        public string authorKana { get; set; }
        //出版社名
        public string publisherName { get; set; }
        //書籍のサイズ
        public string size { get; set; }
        //ISBNコード
        public string isbn { get; set; }
        //商品説明文
        public string itemCaption { get; set; }
        //発売日
        public string salesDate { get; set; }
        //税込み販売価格
        public string itemPrice { get; set; }
        ////定価
        //public string listPrice { get; set; }
        ////割引率
        //public string discountRate { get; set; }
        ////割引額
        //public string discountPrice { get; set; }

        //商品URL
        public string itemUrl { get; set; }
        //アフェリエイトURL
        public string affiliateUrl { get; set; }
        //商品画像
        public string imageUrl { get; set; }
        //チラよみURL
        public string chirayomiUrl { get; set; }
        //在庫状況
        public string availability { get; set; }
        //送料フラグ
        public string postageFlag { get; set; }
        //限定フラグ
        public string limitedFlag { get; set; }
        //レビュー件数
        public string reviewCount { get; set; }
        //レビュー平均
        public string reviewAverage { get; set; }
        //楽天ブックスジャンルID
        public string booksGenreId { get; set; }
    }
}





