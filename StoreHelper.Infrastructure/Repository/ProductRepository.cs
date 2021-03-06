﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreHelper.Domain.Model.Product;

namespace StoreHelper.Infrastructure.Repository
{
    public sealed class ProductRepository
    {

        #region data

        private readonly Dictionary<string, Product> _products;

        #endregion

        #region constructor

        public ProductRepository()
        {
            this._products = new Dictionary<string, Product>();
            var product = Product.CreateANewProduct("テスト", SalesPeriod.SellYearRound(), null, 3.5);
            this._products.Add(product.Describe().Id, product);
            product = Product.CreateANewProduct("テスト２", SalesPeriod.SellInLimitedTime(6, RoughDay.middle, 10, RoughDay.beginning), null, 2.8);
            this._products.Add(product.Describe().Id, product);
        }

        #endregion

        #region fetch

        public IEnumerable<Product> Products()
        {
            return this._products.Values;
        }

        #endregion

    }
}
