namespace MultiShop.RapidAPI.WebApp.ModelViews
{
    public class RealTimeProductView
    {

        public class Rootobject
        {
            public string status { get; set; }
            public string request_id { get; set; }
            public Datum[] data { get; set; }
        }

        public class Datum
        {
            public string product_id { get; set; }
            public string product_title { get; set; }
            public string product_description { get; set; }
            public string[] product_photos { get; set; }
            public Product_Attributes product_attributes { get; set; }
            public float? product_rating { get; set; }
            public string product_page_url { get; set; }
            public string product_offers_page_url { get; set; }
            public string product_specs_page_url { get; set; }
            public string product_reviews_page_url { get; set; }
            public int product_num_reviews { get; set; }
            public string product_num_offers { get; set; }
            public string[] typical_price_range { get; set; }
            public Offer offer { get; set; }
        }

        public class Product_Attributes
        {
            public string Department { get; set; }
            public string Size { get; set; }
            public string Material { get; set; }
            public string Color { get; set; }
            public string Features { get; set; }
            public string ClosureStyle { get; set; }
            public string Style { get; set; }
            public string AthleticStyle { get; set; }
            public string ToddlerDepartment { get; set; }
            public string Pattern { get; set; }
        }

        public class Offer
        {
            public string store_name { get; set; }
            public object store_rating { get; set; }
            public string offer_page_url { get; set; }
            public int store_review_count { get; set; }
            public object store_reviews_page_url { get; set; }
            public string price { get; set; }
            public string shipping { get; set; }
            public string tax { get; set; }
            public bool on_sale { get; set; }
            public string original_price { get; set; }
            public string product_condition { get; set; }
            public bool top_quality_store { get; set; }
            public string buy_now_url { get; set; }
        }

    }
}
