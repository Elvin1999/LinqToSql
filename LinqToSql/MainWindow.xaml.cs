
using System.Windows;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace LinqToSql
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<T> ToObservableCollection<T>(IEnumerable<T> list)
        {
            return new ObservableCollection<T>(list);
        }
        public MainWindow()
        {
            InitializeComponent();
            DataClasses1DataContext dtx = new DataClasses1DataContext();

            //IQueryable<Book> result = from b in dtx.Books
            //                          where b.Pages > 300
            //                          select b;
            //var result2 = dtx
            //    .Books
            //    .Where(b => b.Pages > 300);


            //var result = from b in dtx.Books
            //                          where b.Pages > 300
            //                          select new
            //                          {
            //                              b.Id,
            //                              b.Name,
            //                              b.Pages
            //                          };



            //var result = from b in dtx.Books
            //             where b.Pages > 300
            //             select new
            //             {
            //                 b.Id_Category,
            //                 b.Category.Name,
            //                 b.Pages
            //             };


            //var result = (from b in dtx.Books
            //             where b.Id == 1
            //             select b);



            var result = from b in dtx.Books
                         where b.Pages > 400
                         select b;
            //group b by b.Id_Category into mygroup
            //select new { mygroup.Key, mygroup.First().Category.Name };
           // var aa = result.Select(r => new Book { Id = r.Id });
            var a = new ObservableCollection<Book>(result);

            var linq = ToObservableCollection(result.OrderByDescending(x => x.Name));

            //var result = from c in dtx.S_Cards
            //            group c by c.Id_Book into mygroup
            //            select new { mygroup.Count() };


            //var result = dtx.S_Cards.GroupBy(c => c.Id_Book)
            //     .Select(g => new { g.First().Book.Name, Count = g.Count() })
            //     .OrderByDescending(o=>o.Count)
            //     .Take(1);



            //var result = from book in dtx.Books
            //             where book.Id == ((from b in dtx.Books
            //                                orderby b.Pages descending
            //                                select b.Id)
            //            .Take(1).First())
            //             select book;



            //mydatagrid.ItemsSource = result;


            //var query = from b in dtx.Books
            //            join a in dtx.Authors on b.Id_Author equals a.Id
            //            select new { b.Name, a.FirstName };
            //mydatagrid.ItemsSource = query;

            #region InsertToDb


            //dtx.Books.InsertOnSubmit(
            //    new Book
            //    {
            //        Id=1112,
            //         Name="My Super Book",
            //          Pages=10000,
            //           YearPress=2021,
            //           Id_Category=1,
            //            Id_Author=1,
            //             Id_Press=1,
            //              Id_Themes=1
            //    }
            //    );
            //dtx.SubmitChanges();
            #endregion


            #region Update

            //var book = dtx.Books.FirstOrDefault(b => b.Id == 1112);
            //book.Pages = 0;
            //book.Name = "Sehife Sayi Sifirlandi";
            //dtx.SubmitChanges();

            #endregion


            #region Delete

            //var book = dtx.Books.FirstOrDefault(b => b.Id == 1112);
            //dtx.Books.DeleteOnSubmit(book);
            //dtx.SubmitChanges();
            #endregion

            var result = from b in dtx.Books
                         select b;
            mydatagrid.ItemsSource = result;
               

        }
    }
}
