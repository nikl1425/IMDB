using System.Collections.Generic;

namespace DataService
{
    public class DataService
    {
        //private readonly string _connectionString;
        public DataService()
        {
           //using var ctx = new ImdbContext();
        }

/*
        public IList<> GetCategories()
        {
            using var ctx = new NorthWindContext();
            return ctx.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            using var ctx = new NorthWindContext();
            return ctx.Categories.Find(id);
        }

        public Category CreateCategory(string name, string description)
        {
            using var ctx = new NorthWindContext();
            var maxId = ctx.Categories.Max(x => x.Id);
            ctx.Categories.Add(new Category {Id = maxId + 1, Name = name, Description = description});
            ctx.SaveChanges();
            return ctx.Categories.Find(maxId + 1);
        }

        public bool UpdateCategory(int id, string name, string description)
        {
            using var ctx = new NorthWindContext();
            if (id <= 0) return false;
            ctx.Categories.Update(ctx.Categories.Find(id)).Entity.Description = description;
            ctx.Categories.Update(ctx.Categories.Find(id)).Entity.Name = name;
            ctx.SaveChanges();
            return GetCategory(id).Name == name && GetCategory(id).Description == description;
            
        }

        public Product GetProduct(int id)
        {
            using var ctx = new NorthWindContext();
            var itWorks = ctx.Categories.Find(id).Name;
            return ctx.Products.Find(id);
        }
        public IList<Product> GetProductByCategory(int id)
        {
            using var ctx = new NorthWindContext();
            var x = ctx.Products.Where(z => z.Category.Id == id && z.Category.Name == ctx.Categories.Find(id).Name);
            return x.ToList();
        }

        public IList<Product> GetProductByName(string searchString)
        {
            
            using var ctx = new NorthWindContext();
            
                
            
            var x = ctx.Products.Where(z => z.Name.Contains(searchString));
            
            var y = ctx.Products.Where(z => z.Name.Contains(searchString)).ToList();
            
            
            return x.ToList();
        }
        
        public Order GetOrder(int id)
        {
            using var ctx = new NorthWindContext();


            var query3 = ctx.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(d => d.Product)
                .ThenInclude(d => d.Category)
                .AsSingleQuery()
                .FirstOrDefault(o => o.Id == 10248);

            ctx.SaveChanges();

            return query3;
        }

        public bool DeleteCategory(int id)
        {
            using var ctx = new NorthWindContext();
            var dbCat = GetCategory(id);
            if (dbCat == null)
            {
                return false;
            }
            ctx.Categories.Remove(dbCat);
            ctx.SaveChanges();
            return true;
        }
        public List<Order> GetOrders()
        {
            var ctx = new NorthWindContext();

            var result = ctx.Orders;

            return result.ToList();
        }

        public List<OrderDetail> GetOrderDetailsByOrderId(int Id)
        {
            using var ctx = new NorthWindContext();

            var query = ctx.OrderDetail
                .Where(x => x.Orderid == 10248)
                .Include(x => x.Product)
                .ToList();

            return query;
        }

        public List<OrderDetail> GetOrderDetailsByProductId(int id)
        {
            var ctx = new NorthWindContext();

            var query = ctx.OrderDetail
                .Where(x => x.productid == 11)
                .Include(x => x.Order)
                .ToList();

            return query;
        }

        public IList<Product> getProductCategory(int id)
        {
            var ctx = new NorthWindContext();

            var query = ctx.Products.Where(x => x.Category.Id == id).ToList();

            return query;
        }
          */
    }
}