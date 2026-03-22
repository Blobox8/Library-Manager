namespace Library
{
    class Book
    {
        
        private string title;
        private string author;
        //private int id;
        //private int amount;
        private double price;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }


        public double Price
        {
            get{ return price; }
            set { price = value; }
        }
        

        public Book(string title, string author, /*int id, int amount,*/ double price)
        {
            this.title = title;
            this.author = author;
            //this.id = id;
            //this.amount = amount;
            this.price = price;
        }
        
    }
}




