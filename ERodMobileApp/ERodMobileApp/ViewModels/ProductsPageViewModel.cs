using ERodMobileApp.Helpers;
using ERodMobileApp.Models;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ERodMobileApp.ViewModels
{
    public class ProductsPageViewModel : ViewModelBase
    {
        private List<ProductModel> _allProducts;
        public List<ProductModel> AllProducts
        {
            get => _allProducts;
            set => SetProperty(ref _allProducts, value);
        }
        private List<ProductModel> _suckerRod;
        public List<ProductModel> SuckerRod
        {
            get => _suckerRod;
            set => SetProperty(ref _suckerRod, value);
        }
        private List<ProductModel> _ponyRod;
        public List<ProductModel> PonyRod
        {
            get => _ponyRod;
            set => SetProperty(ref _ponyRod, value);
        }
        private List<ProductModel> _coupling;
        public List<ProductModel> Coupling
        {
            get => _coupling;
            set => SetProperty(ref _coupling, value);
        }
        private List<ProductModel> _sinkerBar;
        public List<ProductModel> SinkerBar
        {
            get => _sinkerBar;
            set => SetProperty(ref _sinkerBar, value);
        }
        private List<ProductModel> _otherItem;
        public List<ProductModel> OtherItem
        {
            get => _otherItem;
            set => SetProperty(ref _otherItem, value);
        }
        private List<ProductModel> _rodGuide;
        public List<ProductModel> RodGuide
        {
            get => _rodGuide;
            set => SetProperty(ref _rodGuide, value);
        }
        private List<ProductModel> _polishedRod;
        public List<ProductModel> PolishedRod
        {
            get => _polishedRod;
            set => SetProperty(ref _polishedRod, value);
        }
        private GroupData _tabData;
        public GroupData TabData
        {
            get => _tabData;
            set => SetProperty(ref _tabData, value);
        }
        private string _selectedProductGroup;
        public string SelectedProductGroup
        {
            get => _selectedProductGroup;
            set => SetProperty(ref _selectedProductGroup, value);
        }
        private string _selectedProductGrade;
        public string SelectedProductGrade
        {
            get => _selectedProductGrade;
            set => SetProperty(ref _selectedProductGrade, value);
        }
        private string _selectedProductSize;
        public string SelectedProductSize
        {
            get => _selectedProductSize;
            set => SetProperty(ref _selectedProductSize, value);
        }
        private string _selectedProductLength;
        public string SelectedProductLength
        {
            get => _selectedProductLength;
            set => SetProperty(ref _selectedProductLength, value);
        }
        private string _selectedProductSubGroup;
        public string SelectedProductSubGroup
        {
            get => _selectedProductSubGroup;
            set => SetProperty(ref _selectedProductSubGroup, value);
        }
        private string _selectedProductPinSize;
        public string SelectedProductPinSize
        {
            get => _selectedProductPinSize;
            set => SetProperty(ref _selectedProductPinSize, value);
        }
        private string _selectedProductSubGrade;
        public string SelectedProductSubGrade
        {
            get => _selectedProductSubGrade;
            set => SetProperty(ref _selectedProductSubGrade, value);
        }
        private string _selectedMiscProduct;
        public string SelectedMiscProduct
        {
            get => _selectedMiscProduct;
            set => SetProperty(ref _selectedMiscProduct, value);
        }
        private string _productData;
        public string ProductData
        {
            get => _productData;
            set => SetProperty(ref _productData, value);
        }
        private string _selectedProductImage;
        public string SelectedProductImage
        {
            get => _selectedProductImage;
            set => SetProperty(ref _selectedProductImage, value);
        }
        private string _selectedProductDescription;
        public string SelectedProductDescription
        {
            get => _selectedProductDescription;
            set => SetProperty(ref _selectedProductDescription, value);
        }
        private string _selectedProductQuantity;
        public string SelectedProductQuantity
        {
            get => _selectedProductQuantity;
            set => SetProperty(ref _selectedProductQuantity, value);
        }
        private bool _imageIsVisible;
        public bool ImageIsVisible
        {
            get => _imageIsVisible;
            set => SetProperty(ref _imageIsVisible, value);
        }
        private List<ProductModel> _productList;
        public List<ProductModel> ProductList
        {
            get => _productList;
            set => SetProperty(ref _productList, value);
        }
        public DelegateCommand SuckerRodSelectedCommand { get; set; }
        public DelegateCommand PonyRodSelectedCommand { get; set; }
        public DelegateCommand CouplingsSelectedCommand { get; set; }
        public DelegateCommand SinkerBarSelectedCommand { get; set; }
        public DelegateCommand PolishedRodSelectedCommand { get; set; }
        public DelegateCommand MiscItemSelectedCommand { get; set; }
        public DelegateCommand<string> ProductGradeSelectedCommand { get; set; }
        public DelegateCommand<string> ProductSizeSelectedCommand { get; set; }
        public DelegateCommand<string> ProductLengthSelectedCommand { get; set; }
        public DelegateCommand<string> ProductSubGroupSelectedCommand { get; set; }
        public DelegateCommand<string> ProductPinSizeSelectedCommand { get; set; }
        public DelegateCommand<string> ProductSubGradeSelectedCommand { get; set; }
        public DelegateCommand<string> MiscItemProductSelectedCommand { get; set; }
        public DelegateCommand DeleteAndReturnBtnCommand { get; set; }
        public DelegateCommand SaveAndContinueBtnCommand { get; set; }
        public DelegateCommand AddItemToOrderCommand { get; set; }
        public string NewSalesOrderId { get; set; }
        public SalesOrder NewSalesOrder { get; set; }
        public ProductsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            TabData = new GroupData()
            {
                SelectedGroup = "SuckerRod",
                SelectedGroupBgColor = Color.FromHex("#F0FBFF"),
                SelectedGroupLblColor = Color.FromHex("#FF6600"),
                SelectedGroupType = "Group"
            };
            ImageIsVisible = true;
            SelectedProductQuantity = "0";
            SelectedProductImage = "SuckerRod.png";
            PonyRod = new List<ProductModel>();
            SuckerRod = new List<ProductModel>();
            PolishedRod = new List<ProductModel>();
            SinkerBar = new List<ProductModel>();
            OtherItem = new List<ProductModel>();
            RodGuide = new List<ProductModel>();
            Coupling = new List<ProductModel>();
            GetAllProducts();
            SelectedProductGroup = "SuckerRod";
            SuckerRodSelectedCommand = new DelegateCommand(() => ProductGroupSelected("SuckerRod"));
            PonyRodSelectedCommand = new DelegateCommand(() => ProductGroupSelected("PonyRod"));
            CouplingsSelectedCommand = new DelegateCommand(() => ProductGroupSelected("Couplings"));
            SinkerBarSelectedCommand = new DelegateCommand(() => ProductGroupSelected("SinkerBar"));
            PolishedRodSelectedCommand = new DelegateCommand(() => ProductGroupSelected("PolishedRod"));
            MiscItemSelectedCommand = new DelegateCommand(() => ProductGroupSelected("MiscItem"));
            ProductGradeSelectedCommand = new DelegateCommand<string>(ProductGradeSelected);
            ProductSizeSelectedCommand = new DelegateCommand<string>(ProductSizeSelected);
            ProductLengthSelectedCommand = new DelegateCommand<string>(ProductLengthSelected);
            ProductSubGroupSelectedCommand = new DelegateCommand<string>(ProductSubGroupSelected);
            ProductPinSizeSelectedCommand = new DelegateCommand<string>(ProductPinSizeSelected);
            ProductSubGradeSelectedCommand = new DelegateCommand<string>(ProductSubGradeSelected);
            MiscItemProductSelectedCommand = new DelegateCommand<string>(MiscItemProductSelected);
            DeleteAndReturnBtnCommand = new DelegateCommand(DeleteAndReturn);
            SaveAndContinueBtnCommand = new DelegateCommand(SaveAndContinue);
            AddItemToOrderCommand = new DelegateCommand(AddItemToOrder);
        }
        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            var Toast = DependencyService.Get<IMessage>();
            try
            {
                if (parameters.ContainsKey("NewSOId"))
                {
                    NewSalesOrder = new SalesOrder();
                    var SOID = parameters["NewSOId"] as string;
                    var NewSO = await App.Database.GetSalesOrderByIdAsync(SOID);
                    if (NewSO != null)
                    {
                        NewSalesOrder = new SalesOrder();
                        NewSalesOrder = NewSO;
                    }
                    else
                    {
                        Toast.LongAlert("Order details not found.");
                    }
                }
            }
            catch (Exception e)
            {

            }
        }
        public void ProductGroupSelected(string group)
        {
            TabData = new GroupData()
            {
                SelectedGroup = group,
                SelectedGroupBgColor = Color.FromHex("#F0FBFF"),
                SelectedGroupLblColor = Color.FromHex("#FF6600"),
                SelectedGroupType = "Group"
            };
            SelectedProductGroup = group;
            SelectedProductGrade = string.Empty;
            SelectedProductSize = string.Empty;
            SelectedProductLength = string.Empty;
            SelectedProductSubGroup = string.Empty;
            SelectedProductPinSize = string.Empty;
            SelectedMiscProduct = string.Empty;
            SelectedProductDescription = string.Empty;
            SelectedProductQuantity = "0";

            if (TabData.SelectedGroup == "SuckerRod")
            {
                ProductList = new List<ProductModel>(SuckerRod);
                SelectedProductImage = "SuckerRod.png";
                ImageIsVisible = true;
            }
            if (TabData.SelectedGroup == "PonyRod")
            {
                ProductList = new List<ProductModel>(PonyRod);
                SelectedProductImage = "PonyRod.png";
                ImageIsVisible = true;
            }
            if (TabData.SelectedGroup == "Couplings")
            {
                ProductList = new List<ProductModel>(Coupling);
                SelectedProductImage = "Coupling.png";
                ImageIsVisible = true;
            }
            if (TabData.SelectedGroup == "SinkerBar")
            {
                ProductList = new List<ProductModel>(SinkerBar);
                SelectedProductImage = "SinkerBar.png";
                ImageIsVisible = true;
            }
            if (TabData.SelectedGroup == "PolishedRod")
            {
                ProductList = new List<ProductModel>(PolishedRod);
                SelectedProductImage = "PolishedRod.png";
                ImageIsVisible = true;
            }
            if (TabData.SelectedGroup == "MiscItem")
            {
                ProductList = new List<ProductModel>(OtherItem);
                ImageIsVisible = false;
            }
        }
        public void ProductGradeSelected(string grade)
        {
            SelectedProductGrade = grade;
            if (SelectedProductGroup == "Couplings")
                GetProductItem(grade, "Menu_3_Selection");
            else
                GetProductItem(grade, "Menu_2_Selection");
        }
        public void ProductSizeSelected(string size)
        {
            SelectedProductSize = size;
            if (SelectedProductGroup == "Couplings")
                GetProductItem(size, "Menu_5_Selection");
            else
                GetProductItem(size, "Menu_3_Selection");
        }
        public void ProductLengthSelected(string length)
        {
            SelectedProductLength = length;
            if (SelectedProductGroup == "PolishedRod")
                GetProductItem(length, "Menu_5_Selection");
            else
                GetProductItem(length, "Menu_4_Selection");
        }
        public void ProductSubGroupSelected(string subGroup)
        {
            SelectedProductSubGroup = subGroup;
            GetProductItem(subGroup, "Menu_2_Selection");
        }
        public void ProductPinSizeSelected(string pinSize)
        {
            SelectedProductPinSize = pinSize;
            GetProductItem(pinSize, "Menu_4_Selection");
        }
        public void ProductSubGradeSelected(string subGrade)
        {
            SelectedProductSubGrade = subGrade;
            GetProductItem(subGrade, "Menu_4_Selection");
        }
        public void MiscItemProductSelected(string product)
        {
            SelectedMiscProduct = product;
        }
        public void DeleteAndReturn()
        {
            NavigationService.GoBackAsync();
        }
        public async Task GetAllProducts()
        {
            IsBusy = true;
            try
            {
                var response = await new ApiData().GetData<List<ProductModel>>("api/Products/GetAllEOEParts", true);
                var data = IsNotConnected == false ? response.data : await App.Database.GetAllProductsAsync();
                if (data != null)
                {
                    AllProducts = new List<ProductModel>(data);
                    foreach (var item in AllProducts)
                    {
                        await App.Database.SaveProductAsync(item);
                        if (item.Menu_1_Selection == "Pony Rod")
                            PonyRod.Add(item);
                        if (item.Menu_1_Selection == "Sucker Rod")
                            SuckerRod.Add(item);
                        if (item.Menu_1_Selection == "Sinker Bar")
                            SinkerBar.Add(item);
                        if (item.Menu_1_Selection == "Polished Rod")
                            PolishedRod.Add(item);
                        if (item.Menu_1_Selection == "Rod Guide")
                            RodGuide.Add(item);
                        if (item.Menu_1_Selection == "Other Item")
                            OtherItem.Add(item);
                        if (item.Menu_1_Selection == "Coupling")
                            Coupling.Add(item);
                    }
                    ProductList = new List<ProductModel>(SuckerRod);
                }
                ProductGroupSelected("SuckerRod");

            }
            catch (Exception e)
            {

            }
            IsBusy = false;
            //var item = AllProducts.Find(i => i.Menu_1_Selection == "Sucker Rod" || i.Menu_2_Selection == "EH" || i.Menu_3_Selection == "1 IN" || i.Menu_4_Selection == "25 FT");
        }
        public void GetProductItem(string data, string column)
        {
            if (SelectedProductGroup == "SuckerRod" || SelectedProductGroup == "PonyRod")
            {
                if (column == "Menu_2_Selection")
                {
                    var items = ProductList.Where(i => i.Menu_2_Selection == data).ToList();
                    if (items != null && items.Count != 0)
                    {
                        ProductList = new List<ProductModel>(items);
                    }
                }
                if (column == "Menu_3_Selection")
                {
                    var items = ProductList.Where(i => i.Menu_3_Selection == data).ToList();
                    if (items != null && items.Count != 0)
                    {
                        ProductList = new List<ProductModel>(items);
                    }
                }
                if (column == "Menu_4_Selection")
                {
                    var items = ProductList.Where(i => i.Menu_4_Selection == data).ToList();
                    if (items != null && items.Count != 0)
                    {
                        ProductList = new List<ProductModel>(items);
                    }
                }
            }
            if (SelectedProductGroup == "SinkerBar" || SelectedProductGroup == "PolishedRod")
            {
                if (column == "Menu_2_Selection")
                {
                    var items = ProductList.Where(i => i.Menu_2_Selection == data).ToList();
                    if (items != null && items.Count != 0)
                    {
                        ProductList = new List<ProductModel>(items);
                    }
                }
                if (column == "Menu_3_Selection")
                {
                    var items = ProductList.Where(i => i.Menu_3_Selection == data).ToList();
                    if (items != null && items.Count != 0)
                    {
                        ProductList = new List<ProductModel>(items);
                    }
                }
                if (column == "Menu_4_Selection")
                {
                    var items = ProductList.Where(i => i.Menu_4_Selection == data).ToList();
                    if (items != null && items.Count != 0)
                    {
                        ProductList = new List<ProductModel>(items);
                    }
                }
                if (column == "Menu_5_Selection")
                {
                    var items = ProductList.Where(i => i.Menu_5_Selection == data).ToList();
                    if (items != null && items.Count != 0)
                    {
                        ProductList = new List<ProductModel>(items);
                    }
                }
            }
            if (SelectedProductGroup == "Couplings")
            {
                if (column == "Menu_2_Selection")
                {
                    var items = ProductList.Where(i => i.Menu_2_Selection == data).ToList();
                    if (items != null && items.Count != 0)
                    {
                        ProductList = new List<ProductModel>(items);
                    }
                }
                if (column == "Menu_3_Selection")
                {
                    var items = ProductList.Where(i => i.Menu_3_Selection == data).ToList();
                    if (items != null && items.Count != 0)
                    {
                        ProductList = new List<ProductModel>(items);
                    }
                }
                if (column == "Menu_4_Selection")
                {
                    var items = ProductList.Where(i => i.Menu_4_Selection == data).ToList();
                    if (items != null && items.Count != 0)
                    {
                        ProductList = new List<ProductModel>(items);
                    }
                }
                if (column == "Menu_5_Selection")
                {
                    var items = ProductList.Where(i => i.Menu_5_Selection == data).ToList();
                    if (items != null && items.Count != 0)
                    {
                        ProductList = new List<ProductModel>(items);
                    }
                }
            }
            if (ProductList.Count < 6)
            {
                SelectedProductDescription = ProductList.FirstOrDefault().Description;
            }
        }
        public void AddItemToOrder()
        {
            var Toast = DependencyService.Get<IMessage>();
            if (string.IsNullOrEmpty(SelectedProductDescription))
            {
                Toast.LongAlert("Please select Product.");
            }
            else if (SelectedProductQuantity == "0")
            {
                Toast.LongAlert("Please select Product Quantity.");
            }
            else
            {
                if (NewSalesOrder != null)
                {
                    NewSalesOrder.SOItems.Add(new SalesOrderItemModel { Description = SelectedProductDescription, QtyOrdered = SelectedProductQuantity, QtyToFulfill = SelectedProductQuantity, Id = RadomNumGenerator.RadomNumber(), SoId = NewSalesOrder.Num });
                    Toast.LongAlert("Product added.");
                }
                else
                {
                    Toast.LongAlert("Order not found.");
                }
            }

        }
        public async void SaveAndContinue()
        {
            //try
            //{
            var Toast = DependencyService.Get<IMessage>();
            var result = await App.Database.SaveSalesOrderAsync(NewSalesOrder);
            if (result == 1)
            {
                var navParams = new NavigationParameters();
                navParams.Add("IsFromProductsPage", true);
                navParams.Add("NewSOId", NewSalesOrder.Num);
                await NavigationService.NavigateAsync("EditOrderPage", navParams);
            }
            else
            {
                Toast.LongAlert("Something went wrong.");
            }
            //}
            //catch(Exception e)
            //{

            //}           
        }
    }
}

