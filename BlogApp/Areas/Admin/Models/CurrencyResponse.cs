﻿namespace BlogApp.Areas.Admin.Models
{
    public class Info
    {
        public double rate { get; set; }
        public int timestamp { get; set; }
    }

    public class Query
    {
        public int amount { get; set; }
        public string from { get; set; }
        public string to { get; set; }
    }

    public class CurrencyResponse
    {
        public string date { get; set; }
        public string historical { get; set; }
        public Info info { get; set; }
        public Query query { get; set; }
        public double result { get; set; }
        public bool success { get; set; }
    }
}
