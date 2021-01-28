using ERodMobileApp.Helpers;
using ERodMobileApp.Models;
using Prism.Commands;
using Prism.Navigation;
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
        public ProductsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            PonyRod = new List<ProductModel>();
            SuckerRod = new List<ProductModel>();
            PolishedRod = new List<ProductModel>();
            SinkerBar = new List<ProductModel>();
            OtherItem = new List<ProductModel>();
            RodGuide = new List<ProductModel>();
            Coupling = new List<ProductModel>();
            GetAllProducts();
            TabData = new GroupData()
            {
                SelectedGroup = "SuckerRod",
                SelectedGroupBgColor = Color.FromHex("#F0FBFF"),
                SelectedGroupLblColor = Color.FromHex("#FF6600"),
                SelectedGroupType = "Group"
            };
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

            if (TabData.SelectedGroup == "SuckerRod")
                ProductList = new List<ProductModel>(SuckerRod);
            if (TabData.SelectedGroup == "PonyRod")
                ProductList = new List<ProductModel>(PonyRod);
            if (TabData.SelectedGroup == "Couplings")
                ProductList = new List<ProductModel>(Coupling);
            if (TabData.SelectedGroup == "SinkerBar")
                ProductList = new List<ProductModel>(SinkerBar);
            if (TabData.SelectedGroup == "PolishedRod")
                ProductList = new List<ProductModel>(PolishedRod);
            if (TabData.SelectedGroup == "MiscItem")
                ProductList = new List<ProductModel>(OtherItem);
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
        public async Task GetAllProducts()
        {
            var response = await new ApiData().GetData<List<ProductModel>>("api/Products/GetAllEOEParts", true);
            AllProducts = new List<ProductModel>(response.data);
            foreach (var item in AllProducts)
            {
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
        }
    }
}

