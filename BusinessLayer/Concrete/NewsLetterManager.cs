﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NewsLetterManager : INewsLetterService
    {

        INewsLatterDal _newsletterDal;

        public NewsLetterManager(INewsLatterDal newsletterDal)
        {
            _newsletterDal = newsletterDal;
        }

        public void AddNewsLetter(NewsLetter N)
        {
            _newsletterDal.Insert(N);
        }
    }
}
