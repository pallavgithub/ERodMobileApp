using ERodMobileApp.Converters;
using ERodMobileApp.ViewModels;
using System;
using System.Linq;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ERodMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsPage : ContentPage
    {
        int Counter = 0;
        public ProductsPage()
        {
            InitializeComponent();
            // (BindingContext as ProductsPageViewModel).ProductGroupSelected("SuckerRod");
            //CreateSuckerRodFilters();
            GetData();
           
        }
        public async void GetData()
        {
            await (BindingContext as ProductsPageViewModel).GetAllProducts();
            CreateSuckerRodFilters();
        }
        private void SuckerRodGroup_Tapped(object sender, System.EventArgs e)
        {
            (BindingContext as ProductsPageViewModel).ProductGroupSelected("SuckerRod");
            CreateSuckerRodFilters();
        }
        private void PonyRodGroup_Tapped(object sender, EventArgs e)
        {
            (BindingContext as ProductsPageViewModel).ProductGroupSelected("PonyRod");
            // CreatePonyRodFilters();
            CreateSuckerRodFilters();
        }
        private void CouplingsGroup_Tapped(object sender, EventArgs e)
        {
            (BindingContext as ProductsPageViewModel).ProductGroupSelected("Couplings");
            CreateCouplingsFilters();
        }
        private void SinkerBarGroup_Tapped(object sender, EventArgs e)
        {
            (BindingContext as ProductsPageViewModel).ProductGroupSelected("SinkerBar");
            CreateSinkerBarFilters();
        }
        private void PolishedRodGroup_Tapped(object sender, EventArgs e)
        {
            (BindingContext as ProductsPageViewModel).ProductGroupSelected("PolishedRod");
            CreatePolishedRodFilters();
        }
        public void CreateSuckerRodFilters()
        {
            SelectedFrameBgColor FrameColorConverter = new SelectedFrameBgColor();
            SelectedLabelColorConverter LabelColorConverter = new SelectedLabelColorConverter();

            try
            {
                var Grades = (BindingContext as ProductsPageViewModel).ProductList.Select(x => x.Menu_2_Selection).Distinct().ToList();
                var stack = new StackLayout
                {
                    Children =
                    {
                        new Frame
                        {
                            HasShadow=false ,
                            OutlineColor=Color.Gray,
                            HeightRequest=35,
                            Padding=new Thickness(15,0,0,0),
                            CornerRadius=10 ,
                            Content=new Label
                            {
                                Text="2. Select Product Grade",
                                TextColor=Color.FromHex("#FF6600") ,
                                FontFamily="{StaticResource InterMedium}",
                                 FontSize=22
                            }
                        },
                    }
                };
                var grade_grid = new Grid
                {
                    RowSpacing = 10,
                    ColumnSpacing = 8,
                    Margin = new Thickness(0, 5, 0, 5),
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                var grade_rowcount = (int)Math.Ceiling(((double)Grades.Count) / 2);
                for (int i = 0; i < grade_rowcount; i++)
                {
                    grade_grid.RowDefinitions.Add(new RowDefinition { Height = 35 });
                }
                grade_grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                grade_grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                var grade_Index = 0;
                for (int rowIndex = 0; rowIndex < grade_rowcount; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < 2; columnIndex++)
                    {
                        if (grade_Index >= Grades.Count)
                        {
                            break;
                        }
                        var grade = Grades[grade_Index];
                        if (Grades.Count >= grade_Index)
                        {
                            var frame = new Frame
                            {
                                OutlineColor = Color.FromHex("#50555C"),
                                HasShadow = false,
                                Padding = new Thickness(0),
                                Content = new Label
                                {
                                    Text = grade,
                                    VerticalOptions = LayoutOptions.Center,
                                    HorizontalOptions = LayoutOptions.Center,
                                }
                            };
                            Binding frameColorBinding = new Binding("SelectedProductGrade");
                            frameColorBinding.Converter = FrameColorConverter;
                            frameColorBinding.ConverterParameter = grade;
                            frame.SetBinding(BackgroundColorProperty, frameColorBinding);
                            Binding lblColorBinding = new Binding("SelectedProductGrade");
                            lblColorBinding.Converter = LabelColorConverter;
                            lblColorBinding.ConverterParameter = grade;
                            (frame.Children[0] as Label).SetBinding(Label.TextColorProperty, lblColorBinding);
                            var tapGestureRecognizer = new TapGestureRecognizer();
                            tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, "ProductGradeSelectedCommand");
                            tapGestureRecognizer.CommandParameter = grade;
                            frame.GestureRecognizers.Add(tapGestureRecognizer);
                            grade_grid.Children.Add(frame, columnIndex, rowIndex);
                        }
                        grade_Index += 1;
                    }
                }
                stack.Children.Add(grade_grid);

                var Size = (BindingContext as ProductsPageViewModel).ProductList.Select(x => x.Menu_3_Selection).Distinct().ToList();
                var sizeFrame = new Frame
                {
                    HasShadow = false,
                    OutlineColor = Color.Gray,
                    HeightRequest = 35,
                    Padding = new Thickness(15, 0, 0, 0),
                    CornerRadius = 10,
                    Content = new Label
                    {
                        Text = "3. Select Product Size",
                        TextColor = Color.FromHex("#FF6600"),
                        FontFamily = "{StaticResource InterMedium}",
                        FontSize = 22
                    }
                };
                var size_grid = new Grid
                {
                    RowSpacing = 10,
                    ColumnSpacing = 8,
                    Margin = new Thickness(5),
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                var size_rowcount = (int)Math.Ceiling(((double)Size.Count) / 2);
                for (int i = 0; i < size_rowcount; i++)
                {
                    size_grid.RowDefinitions.Add(new RowDefinition { Height = 35 });
                }
                size_grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                size_grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                var size_Index = 0;
                for (int rowIndex = 0; rowIndex < size_rowcount; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < 2; columnIndex++)
                    {
                        if (size_Index >= Size.Count)
                        {
                            break;
                        }
                        var size = Size[size_Index];
                        if (Size.Count >= size_Index)
                        {
                            var frame = new Frame
                            {
                                OutlineColor = Color.FromHex("#50555C"),
                                HasShadow = false,
                                Padding = new Thickness(0),
                                Content = new Label
                                {
                                    Text = size,
                                    VerticalOptions = LayoutOptions.Center,
                                    HorizontalOptions = LayoutOptions.Center
                                }
                            }; 
                            Binding frameColorBinding = new Binding("SelectedProductSize");
                            frameColorBinding.Converter = FrameColorConverter;
                            frameColorBinding.ConverterParameter = size;
                            frame.SetBinding(BackgroundColorProperty, frameColorBinding);
                            Binding lblColorBinding = new Binding("SelectedProductSize");
                            lblColorBinding.Converter = LabelColorConverter;
                            lblColorBinding.ConverterParameter = size;
                            (frame.Children[0] as Label).SetBinding(Label.TextColorProperty, lblColorBinding);
                            var tapGestureRecognizer = new TapGestureRecognizer();
                            tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, "ProductSizeSelectedCommand");
                            tapGestureRecognizer.CommandParameter = size;
                            frame.GestureRecognizers.Add(tapGestureRecognizer);
                            size_grid.Children.Add(frame, columnIndex, rowIndex);
                        }
                        size_Index += 1;
                    }
                }
                stack.Children.Add(sizeFrame);
                stack.Children.Add(size_grid);

                var Length = (BindingContext as ProductsPageViewModel).ProductList.Select(x => x.Menu_4_Selection).Distinct().ToList();
                var lengthFrame = new Frame
                {
                    HasShadow = false,
                    OutlineColor = Color.Gray,
                    HeightRequest = 35,
                    Padding = new Thickness(15, 0, 0, 0),
                    CornerRadius = 10,
                    Content = new Label
                    {
                        Text = "4. Select Product Length",
                        TextColor = Color.FromHex("#FF6600"),
                        FontFamily = "{StaticResource InterMedium}",
                        FontSize = 22
                    }
                };
                var length_grid = new Grid
                {
                    RowSpacing = 10,
                    ColumnSpacing = 8,
                    Margin = new Thickness(5),
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                var length_rowcount = (int)Math.Ceiling(((double)Length.Count) / 2);
                var length_columncount = (int)Math.Ceiling(((double)Length.Count) / 2);
                for (int i = 0; i < length_rowcount; i++)
                {
                    length_grid.RowDefinitions.Add(new RowDefinition { Height = 35 });
                }
                length_grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                length_grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                var length_Index = 0;
                for (int rowIndex = 0; rowIndex < length_rowcount; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < 2; columnIndex++)
                    {
                        if (length_Index >= Length.Count)
                        {
                            break;
                        }
                        var length = Length[length_Index];
                        if (Length.Count >= length_Index)
                        {
                            var frame = new Frame
                            {
                                OutlineColor = Color.FromHex("#50555C"),
                                HasShadow = false,
                                Padding = new Thickness(0),
                                Content = new Label
                                {
                                    Text = length,
                                    VerticalOptions = LayoutOptions.Center,
                                    HorizontalOptions = LayoutOptions.Center
                                }
                            };
                            Binding frameColorBinding = new Binding("SelectedProductLength");
                            frameColorBinding.Converter = FrameColorConverter;
                            frameColorBinding.ConverterParameter = length;
                            frame.SetBinding(BackgroundColorProperty, frameColorBinding);
                            Binding lblColorBinding = new Binding("SelectedProductLength");
                            lblColorBinding.Converter = LabelColorConverter;
                            lblColorBinding.ConverterParameter = length;
                            (frame.Children[0] as Label).SetBinding(Label.TextColorProperty, lblColorBinding);
                            var tapGestureRecognizer = new TapGestureRecognizer();
                            tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, "ProductLengthSelectedCommand");
                            tapGestureRecognizer.CommandParameter = length;
                            frame.GestureRecognizers.Add(tapGestureRecognizer);
                            length_grid.Children.Add(frame, columnIndex, rowIndex);
                        }
                        length_Index += 1;
                    }
                }
                stack.Children.Add(lengthFrame);
                stack.Children.Add(length_grid);


                var quantityFrame = new Frame
                {
                    HasShadow = false,
                    OutlineColor = Color.Gray,
                    HeightRequest = 35,
                    Padding = new Thickness(15, 0, 0, 0),
                    CornerRadius = 10,
                    Content = new Label
                    {
                        Text = "6. Select Quantity",
                        TextColor = Color.FromHex("#FF6600"),
                        FontFamily = "{StaticResource InterMedium}",
                        FontSize = 22
                    }
                };
                var quantityStack = new StackLayout
                {
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    Orientation = StackOrientation.Horizontal
                };
                var minus_frame = new Frame
                {
                    BackgroundColor = Color.FromHex("#50555C"),
                    Padding = new Thickness(0),
                    HeightRequest = 35,
                    WidthRequest = 35,
                    HasShadow = false,
                    Content = new Label
                    {
                        Text = "-",
                        FontFamily = "{StaticResource InterBold}",
                        TextColor = Color.White,
                        FontSize = 22,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    }
                };
                var quantityValue_frame = new Frame
                {
                    BackgroundColor = Color.FromHex("White"),
                    OutlineColor = Color.LightGray,
                    Padding = new Thickness(0),
                    HeightRequest = 35,
                    WidthRequest = 35,
                    HasShadow = false,
                    Content = new Label
                    {
                        Text = "123",
                        FontFamily = "{StaticResource InterBold}",
                        TextColor = Color.Black,
                        FontSize = 22,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    }
                };
                var plus_frame = new Frame
                {
                    BackgroundColor = Color.FromHex("#50555C"),
                    Padding = new Thickness(0),
                    HeightRequest = 35,
                    WidthRequest = 35,
                    HasShadow = false,
                    Content = new Label
                    {
                        Text = "+",
                        FontFamily = "{StaticResource InterBold}",
                        TextColor = Color.White,
                        FontSize = 22,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    }
                };
                quantityStack.Children.Add(minus_frame);
                quantityStack.Children.Add(quantityValue_frame);
                quantityStack.Children.Add(plus_frame);
                stack.Children.Add(quantityFrame);
                stack.Children.Add(quantityStack);

                if (Counter == 0)
                {
                    InnerStack.Children.Add(stack);
                    Counter = 1;
                }
                else
                {
                    InnerStack.Children.RemoveAt(0);
                    InnerStack.Children.Add(stack);
                }
            }
            catch (Exception e)
            {

            }
        }
        public void CreatePonyRodFilters()
        {
            try
            {
                var Grades = (BindingContext as ProductsPageViewModel).ProductList.Select(x => x.Menu_2_Selection).Distinct().ToList();
                var stack = new StackLayout
                {
                    Children =
                    {
                        new Frame
                        {
                            HasShadow=false ,
                            OutlineColor=Color.Gray,
                            HeightRequest=35,
                            Padding=new Thickness(15,0,0,0),
                            CornerRadius=10 ,
                            Content=new Label
                            {
                                Text="2. Select Product Grade",
                                TextColor=Color.FromHex("#FF6600") ,
                                FontFamily="{StaticResource InterMedium}",
                                 FontSize=22
                            }
                        },
                    }
                };
                var grade_grid = new Grid
                {
                    RowSpacing = 10,
                    ColumnSpacing = 8,
                    Margin = new Thickness(5),
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                var grade_rowcount = (int)Math.Ceiling(((double)Grades.Count) / 2);
                for (int i = 0; i < grade_rowcount; i++)
                {
                    grade_grid.RowDefinitions.Add(new RowDefinition { Height = 35 });
                }
                grade_grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                grade_grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                var grade_Index = 0;
                for (int rowIndex = 0; rowIndex < grade_rowcount; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < 2; columnIndex++)
                    {
                        if (grade_Index >= Grades.Count)
                        {
                            break;
                        }
                        var grade = Grades[grade_Index];
                        if (Grades.Count >= grade_Index)
                        {
                            var frame = new Frame
                            {
                                OutlineColor = Color.FromHex("#50555C"),
                                HasShadow = false,
                                Padding = new Thickness(0),
                                Content = new Label
                                {
                                    Text = grade,
                                    VerticalOptions = LayoutOptions.Center,
                                    HorizontalOptions = LayoutOptions.Center
                                }
                            };
                            var tapGestureRecognizer = new TapGestureRecognizer();
                            tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, "ProductGradeSelectedCommand");
                            tapGestureRecognizer.CommandParameter = grade;
                            frame.GestureRecognizers.Add(tapGestureRecognizer);
                            grade_grid.Children.Add(frame, columnIndex, rowIndex);
                        }
                        grade_Index += 1;
                    }
                }
                stack.Children.Add(grade_grid);

                var Size = (BindingContext as ProductsPageViewModel).ProductList.Select(x => x.Menu_3_Selection).Distinct().ToList();
                var sizeFrame = new Frame
                {
                    HasShadow = false,
                    OutlineColor = Color.Gray,
                    HeightRequest = 35,
                    Padding = new Thickness(15, 0, 0, 0),
                    CornerRadius = 10,
                    Content = new Label
                    {
                        Text = "3. Select Product Size",
                        TextColor = Color.FromHex("#FF6600"),
                        FontFamily = "{StaticResource InterMedium}",
                        FontSize = 22
                    }
                };
                var size_grid = new Grid
                {
                    RowSpacing = 10,
                    ColumnSpacing = 8,
                    Margin = new Thickness(5),
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                var size_rowcount = (int)Math.Ceiling(((double)Size.Count) / 2);
                for (int i = 0; i < size_rowcount; i++)
                {
                    size_grid.RowDefinitions.Add(new RowDefinition { Height = 35 });
                }
                size_grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                size_grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                var size_Index = 0;
                for (int rowIndex = 0; rowIndex < size_rowcount; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < 2; columnIndex++)
                    {
                        if (size_Index >= Size.Count)
                        {
                            break;
                        }
                        var size = Size[size_Index];
                        if (Size.Count >= size_Index)
                        {
                            var frame = new Frame
                            {
                                OutlineColor = Color.FromHex("#50555C"),
                                HasShadow = false,
                                Padding = new Thickness(0),
                                Content = new Label
                                {
                                    Text = size,
                                    VerticalOptions = LayoutOptions.Center,
                                    HorizontalOptions = LayoutOptions.Center
                                }
                            };
                            var tapGestureRecognizer = new TapGestureRecognizer();
                            tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, "ProductSizeSelectedCommand");
                            tapGestureRecognizer.CommandParameter = size;
                            frame.GestureRecognizers.Add(tapGestureRecognizer);
                            size_grid.Children.Add(frame, columnIndex, rowIndex);
                        }
                        size_Index += 1;
                    }
                }
                stack.Children.Add(sizeFrame);
                stack.Children.Add(size_grid);

                var Length = (BindingContext as ProductsPageViewModel).ProductList.Select(x => x.Menu_4_Selection).Distinct().ToList();
                var lengthFrame = new Frame
                {
                    HasShadow = false,
                    OutlineColor = Color.Gray,
                    HeightRequest = 35,
                    Padding = new Thickness(15, 0, 0, 0),
                    CornerRadius = 10,
                    Content = new Label
                    {
                        Text = "4. Select Product Length",
                        TextColor = Color.FromHex("#FF6600"),
                        FontFamily = "{StaticResource InterMedium}",
                        FontSize = 22
                    }
                };
                var length_grid = new Grid
                {
                    RowSpacing = 10,
                    ColumnSpacing = 8,
                    Margin = new Thickness(5),
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                var length_rowcount = (int)Math.Ceiling(((double)Length.Count) / 2);
                var length_columncount = (int)Math.Ceiling(((double)Length.Count) / 2);
                for (int i = 0; i < length_rowcount; i++)
                {
                    length_grid.RowDefinitions.Add(new RowDefinition { Height = 35 });
                }
                length_grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                length_grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                var length_Index = 0;
                for (int rowIndex = 0; rowIndex < length_rowcount; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < 2; columnIndex++)
                    {
                        if (length_Index >= Length.Count)
                        {
                            break;
                        }
                        var length = Length[length_Index];
                        if (Length.Count >= length_Index)
                        {
                            var frame = new Frame
                            {
                                OutlineColor = Color.FromHex("#50555C"),
                                HasShadow = false,
                                Padding = new Thickness(0),
                                Content = new Label
                                {
                                    Text = length,
                                    VerticalOptions = LayoutOptions.Center,
                                    HorizontalOptions = LayoutOptions.Center
                                }
                            };
                            var tapGestureRecognizer = new TapGestureRecognizer();
                            tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, "ProductLengthSelectedCommand");
                            tapGestureRecognizer.CommandParameter = length;
                            frame.GestureRecognizers.Add(tapGestureRecognizer);
                            length_grid.Children.Add(frame, columnIndex, rowIndex);
                        }
                        length_Index += 1;
                    }
                }
                stack.Children.Add(lengthFrame);
                stack.Children.Add(length_grid);

                var quantityFrame = new Frame
                {
                    HasShadow = false,
                    OutlineColor = Color.Gray,
                    HeightRequest = 35,
                    Padding = new Thickness(15, 0, 0, 0),
                    CornerRadius = 10,
                    Content = new Label
                    {
                        Text = "6. Select Quantity",
                        TextColor = Color.FromHex("#FF6600"),
                        FontFamily = "{StaticResource InterMedium}",
                        FontSize = 22
                    }
                };
                var quantityStack = new StackLayout
                {
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    Orientation = StackOrientation.Horizontal
                };
                var minus_frame = new Frame
                {
                    BackgroundColor = Color.FromHex("#50555C"),
                    Padding = new Thickness(0),
                    HeightRequest = 35,
                    WidthRequest = 35,
                    HasShadow = false,
                    Content = new Label
                    {
                        Text = "-",
                        FontFamily = "{StaticResource InterBold}",
                        TextColor = Color.White,
                        FontSize = 22,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    }
                };
                var quantityValue_frame = new Frame
                {
                    BackgroundColor = Color.FromHex("White"),
                    OutlineColor = Color.LightGray,
                    Padding = new Thickness(0),
                    HeightRequest = 35,
                    WidthRequest = 35,
                    HasShadow = false,
                    Content = new Label
                    {
                        Text = "123",
                        FontFamily = "{StaticResource InterBold}",
                        TextColor = Color.Black,
                        FontSize = 22,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    }
                };
                var plus_frame = new Frame
                {
                    BackgroundColor = Color.FromHex("#50555C"),
                    Padding = new Thickness(0),
                    HeightRequest = 35,
                    WidthRequest = 35,
                    HasShadow = false,
                    Content = new Label
                    {
                        Text = "+",
                        FontFamily = "{StaticResource InterBold}",
                        TextColor = Color.White,
                        FontSize = 22,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    }
                };
                quantityStack.Children.Add(minus_frame);
                quantityStack.Children.Add(quantityValue_frame);
                quantityStack.Children.Add(plus_frame);
                stack.Children.Add(quantityFrame);
                stack.Children.Add(quantityStack);


                if (Counter == 0)
                {
                    InnerStack.Children.Add(stack);
                    Counter = 1;
                }
                else
                {
                    InnerStack.Children.RemoveAt(0);
                    InnerStack.Children.Add(stack);
                }
            }
            catch (Exception e)
            {

            }
        }
        public void CreateCouplingsFilters()
        {
            SelectedFrameBgColor FrameColorConverter = new SelectedFrameBgColor();
            SelectedLabelColorConverter LabelColorConverter = new SelectedLabelColorConverter();
            try
            {
                var SubGroups = (BindingContext as ProductsPageViewModel).ProductList.Select(x => x.Menu_2_Selection).Distinct().ToList();
                var stack = new StackLayout
                {
                    Children =
                    {
                        new Frame
                        {
                            HasShadow=false ,
                            OutlineColor=Color.Gray,
                            HeightRequest=35,
                            Padding=new Thickness(15,0,0,0),
                            CornerRadius=10 ,
                            Content=new Label
                            {
                                Text="2. Select Sub-Group",
                                TextColor=Color.FromHex("#FF6600") ,
                                FontFamily="{StaticResource InterMedium}",
                                 FontSize=22
                            }
                        },
                    }
                };
                var subGroup_grid = new Grid
                {
                    RowSpacing = 10,
                    ColumnSpacing = 8,
                    Margin = new Thickness(5),
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                var subGroup_rowcount = (int)Math.Ceiling(((double)SubGroups.Count) / 2);
                for (int i = 0; i < subGroup_rowcount; i++)
                {
                    subGroup_grid.RowDefinitions.Add(new RowDefinition { Height = 35 });
                }
                subGroup_grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                subGroup_grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                var subGroup_Index = 0;
                for (int rowIndex = 0; rowIndex < subGroup_rowcount; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < 2; columnIndex++)
                    {
                        if (subGroup_Index >= SubGroups.Count)
                        {
                            break;
                        }
                        var subgroup = SubGroups[subGroup_Index];
                        if (SubGroups.Count >= subGroup_Index)
                        {
                            var frame = new Frame
                            {
                                OutlineColor = Color.FromHex("#50555C"),
                                HasShadow = false,
                                Padding = new Thickness(0),
                                Content = new Label
                                {
                                    Text = subgroup,
                                    VerticalOptions = LayoutOptions.Center,
                                    HorizontalOptions = LayoutOptions.Center
                                }
                            };
                            Binding frameColorBinding = new Binding("SelectedProductSubGroup");
                            frameColorBinding.Converter = FrameColorConverter;
                            frameColorBinding.ConverterParameter = subgroup;
                            frame.SetBinding(BackgroundColorProperty, frameColorBinding);
                            Binding lblColorBinding = new Binding("SelectedProductSubGroup");
                            lblColorBinding.Converter = LabelColorConverter;
                            lblColorBinding.ConverterParameter = subgroup;
                            (frame.Children[0] as Label).SetBinding(Label.TextColorProperty, lblColorBinding);
                            var tapGestureRecognizer = new TapGestureRecognizer();
                            tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, "ProductSubGroupSelectedCommand");
                            tapGestureRecognizer.CommandParameter = subgroup;
                            frame.GestureRecognizers.Add(tapGestureRecognizer);
                            subGroup_grid.Children.Add(frame, columnIndex, rowIndex);
                        }
                        subGroup_Index += 1;
                    }
                }
                stack.Children.Add(subGroup_grid);

                var Grades = (BindingContext as ProductsPageViewModel).ProductList.Select(x => x.Menu_3_Selection).Distinct().ToList();
                var gradeFrame = new Frame
                {
                    HasShadow = false,
                    OutlineColor = Color.Gray,
                    HeightRequest = 35,
                    Padding = new Thickness(15, 0, 0, 0),
                    CornerRadius = 10,
                    Content = new Label
                    {
                        Text = "3. Select Product Grade",
                        TextColor = Color.FromHex("#FF6600"),
                        FontFamily = "{StaticResource InterMedium}",
                        FontSize = 22
                    }
                };
                var grade_grid = new Grid
                {
                    RowSpacing = 10,
                    ColumnSpacing = 8,
                    Margin = new Thickness(5),
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                var grade_rowcount = (int)Math.Ceiling(((double)Grades.Count) / 2);
                for (int i = 0; i < grade_rowcount; i++)
                {
                    grade_grid.RowDefinitions.Add(new RowDefinition { Height = 35 });
                }
                grade_grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                grade_grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                var grade_Index = 0;
                for (int rowIndex = 0; rowIndex < grade_rowcount; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < 2; columnIndex++)
                    {
                        if (grade_Index >= Grades.Count)
                        {
                            break;
                        }
                        var grade = Grades[grade_Index];
                        if (Grades.Count >= grade_Index)
                        {
                            var frame = new Frame
                            {
                                OutlineColor = Color.FromHex("#50555C"),
                                HasShadow = false,
                                Padding = new Thickness(0),
                                Content = new Label
                                {
                                    Text = grade,
                                    VerticalOptions = LayoutOptions.Center,
                                    HorizontalOptions = LayoutOptions.Center
                                }
                            };
                            Binding frameColorBinding = new Binding("SelectedProductGrade");
                            frameColorBinding.Converter = FrameColorConverter;
                            frameColorBinding.ConverterParameter = grade;
                            frame.SetBinding(BackgroundColorProperty, frameColorBinding);
                            Binding lblColorBinding = new Binding("SelectedProductGrade");
                            lblColorBinding.Converter = LabelColorConverter;
                            lblColorBinding.ConverterParameter = grade;
                            (frame.Children[0] as Label).SetBinding(Label.TextColorProperty, lblColorBinding);
                            var tapGestureRecognizer = new TapGestureRecognizer();
                            tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, "ProductGradeSelectedCommand");
                            tapGestureRecognizer.CommandParameter = grade;
                            frame.GestureRecognizers.Add(tapGestureRecognizer);
                            grade_grid.Children.Add(frame, columnIndex, rowIndex);
                        }
                        grade_Index += 1;
                    }
                }
                stack.Children.Add(gradeFrame);
                stack.Children.Add(grade_grid);

                var SubGrades = (BindingContext as ProductsPageViewModel).ProductList.Select(x => x.Menu_4_Selection).Distinct().ToList();
                var subGradeFrame = new Frame
                {
                    HasShadow = false,
                    OutlineColor = Color.Gray,
                    HeightRequest = 35,
                    Padding = new Thickness(15, 0, 0, 0),
                    CornerRadius = 10,
                    Content = new Label
                    {
                        Text = "4. Select Product Sub-Grade",
                        TextColor = Color.FromHex("#FF6600"),
                        FontFamily = "{StaticResource InterMedium}",
                        FontSize = 22
                    }
                };
                var subGrade_grid = new Grid
                {
                    RowSpacing = 10,
                    ColumnSpacing = 8,
                    Margin = new Thickness(5),
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                var subGrade_rowcount = (int)Math.Ceiling(((double)SubGrades.Count) / 2);
                var subGrade_columncount = (int)Math.Ceiling(((double)SubGrades.Count) / 2);
                for (int i = 0; i < subGrade_rowcount; i++)
                {
                    subGrade_grid.RowDefinitions.Add(new RowDefinition { Height = 35 });
                }
                subGrade_grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                subGrade_grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                var subGrade_Index = 0;
                for (int rowIndex = 0; rowIndex < subGrade_rowcount; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < 2; columnIndex++)
                    {
                        if (subGrade_Index >= SubGrades.Count)
                        {
                            break;
                        }
                        var subgrade = SubGrades[subGrade_Index];
                        if (SubGrades.Count >= subGrade_Index)
                        {
                            var frame = new Frame
                            {
                                OutlineColor = Color.FromHex("#50555C"),
                                HasShadow = false,
                                Padding = new Thickness(0),
                                Content = new Label
                                {
                                    Text = subgrade,
                                    VerticalOptions = LayoutOptions.Center,
                                    HorizontalOptions = LayoutOptions.Center
                                }
                            };
                            Binding frameColorBinding = new Binding("SelectedProductSubGrade");
                            frameColorBinding.Converter = FrameColorConverter;
                            frameColorBinding.ConverterParameter = subgrade;
                            frame.SetBinding(BackgroundColorProperty, frameColorBinding);
                            Binding lblColorBinding = new Binding("SelectedProductSubGrade");
                            lblColorBinding.Converter = LabelColorConverter;
                            lblColorBinding.ConverterParameter = subgrade;
                            (frame.Children[0] as Label).SetBinding(Label.TextColorProperty, lblColorBinding);
                            var tapGestureRecognizer = new TapGestureRecognizer();
                            tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, "ProductSubGradeSelectedCommand");
                            tapGestureRecognizer.CommandParameter = subgrade;
                            frame.GestureRecognizers.Add(tapGestureRecognizer);
                            subGrade_grid.Children.Add(frame, columnIndex, rowIndex);
                        }
                        subGrade_Index += 1;
                    }
                }
                stack.Children.Add(subGradeFrame);
                stack.Children.Add(subGrade_grid);


                var Sizes = (BindingContext as ProductsPageViewModel).ProductList.Select(x => x.Menu_5_Selection).Distinct().ToList();
                var sizeFrame = new Frame
                {
                    HasShadow = false,
                    OutlineColor = Color.Gray,
                    HeightRequest = 35,
                    Padding = new Thickness(15, 0, 0, 0),
                    CornerRadius = 10,
                    Content = new Label
                    {
                        Text = "5. Select Product Size",
                        TextColor = Color.FromHex("#FF6600"),
                        FontFamily = "{StaticResource InterMedium}",
                        FontSize = 22
                    }
                };
                var size_grid = new Grid
                {
                    RowSpacing = 10,
                    ColumnSpacing = 8,
                    Margin = new Thickness(5),
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                var size_rowcount = (int)Math.Ceiling(((double)Sizes.Count) / 2);
                var size_columncount = (int)Math.Ceiling(((double)Sizes.Count) / 2);
                for (int i = 0; i < size_rowcount; i++)
                {
                    size_grid.RowDefinitions.Add(new RowDefinition { Height = 35 });
                }
                size_grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                size_grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                var size_Index = 0;
                for (int rowIndex = 0; rowIndex < size_rowcount; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < 2; columnIndex++)
                    {
                        if (size_Index >= Sizes.Count)
                        {
                            break;
                        }
                        var size = Sizes[size_Index];
                        if (Sizes.Count >= size_Index)
                        {
                            var frame = new Frame
                            {
                                OutlineColor = Color.FromHex("#50555C"),
                                HasShadow = false,
                                Padding = new Thickness(0),
                                Content = new Label
                                {
                                    Text = size,
                                    VerticalOptions = LayoutOptions.Center,
                                    HorizontalOptions = LayoutOptions.Center
                                }
                            };
                            Binding frameColorBinding = new Binding("SelectedProductSize");
                            frameColorBinding.Converter = FrameColorConverter;
                            frameColorBinding.ConverterParameter = size;
                            frame.SetBinding(BackgroundColorProperty, frameColorBinding);
                            Binding lblColorBinding = new Binding("SelectedProductSize");
                            lblColorBinding.Converter = LabelColorConverter;
                            lblColorBinding.ConverterParameter = size;
                            (frame.Children[0] as Label).SetBinding(Label.TextColorProperty, lblColorBinding);
                            var tapGestureRecognizer = new TapGestureRecognizer();
                            tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, "ProductSizeSelectedCommand");
                            tapGestureRecognizer.CommandParameter = size;
                            frame.GestureRecognizers.Add(tapGestureRecognizer);
                            size_grid.Children.Add(frame, columnIndex, rowIndex);
                        }
                        size_Index += 1;
                    }
                }
                stack.Children.Add(sizeFrame);
                stack.Children.Add(size_grid);

                var quantityFrame = new Frame
                {
                    HasShadow = false,
                    OutlineColor = Color.Gray,
                    HeightRequest = 35,
                    Padding = new Thickness(15, 0, 0, 0),
                    CornerRadius = 10,
                    Content = new Label
                    {
                        Text = "6. Select Quantity",
                        TextColor = Color.FromHex("#FF6600"),
                        FontFamily = "{StaticResource InterMedium}",
                        FontSize = 22
                    }
                };
                var quantityStack = new StackLayout
                {
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    Orientation = StackOrientation.Horizontal
                };
                var minus_frame = new Frame
                {
                    BackgroundColor = Color.FromHex("#50555C"),
                    Padding = new Thickness(0),
                    HeightRequest = 35,
                    WidthRequest = 35,
                    HasShadow = false,
                    Content = new Label
                    {
                        Text = "-",
                        FontFamily = "{StaticResource InterBold}",
                        TextColor = Color.White,
                        FontSize = 22,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    }
                };
                var quantityValue_frame = new Frame
                {
                    BackgroundColor = Color.FromHex("White"),
                    OutlineColor = Color.LightGray,
                    Padding = new Thickness(0),
                    HeightRequest = 35,
                    WidthRequest = 35,
                    HasShadow = false,
                    Content = new Label
                    {
                        Text = "123",
                        FontFamily = "{StaticResource InterBold}",
                        TextColor = Color.Black,
                        FontSize = 22,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    }
                };
                var plus_frame = new Frame
                {
                    BackgroundColor = Color.FromHex("#50555C"),
                    Padding = new Thickness(0),
                    HeightRequest = 35,
                    WidthRequest = 35,
                    HasShadow = false,
                    Content = new Label
                    {
                        Text = "+",
                        FontFamily = "{StaticResource InterBold}",
                        TextColor = Color.White,
                        FontSize = 22,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    }
                };
                quantityStack.Children.Add(minus_frame);
                quantityStack.Children.Add(quantityValue_frame);
                quantityStack.Children.Add(plus_frame);
                stack.Children.Add(quantityFrame);
                stack.Children.Add(quantityStack);


                if (Counter == 0)
                {
                    InnerStack.Children.Add(stack);
                    Counter = 1;
                }
                else
                {
                    InnerStack.Children.RemoveAt(0);
                    InnerStack.Children.Add(stack);
                }
            }
            catch (Exception e)
            {

            }
        }
        public void CreateSinkerBarFilters()
        {
            SelectedFrameBgColor FrameColorConverter = new SelectedFrameBgColor();
            SelectedLabelColorConverter LabelColorConverter = new SelectedLabelColorConverter();
            try
            {
                var Grades = (BindingContext as ProductsPageViewModel).ProductList.Select(x => x.Menu_2_Selection).Distinct().ToList();
                var stack = new StackLayout
                {
                    Children =
                    {
                        new Frame
                        {
                            HasShadow=false ,
                            OutlineColor=Color.Gray,
                            HeightRequest=35,
                            Padding=new Thickness(15,0,0,0),
                            CornerRadius=10 ,
                            Content=new Label
                            {
                                Text="2. Select Product Grade",
                                TextColor=Color.FromHex("#FF6600") ,
                                FontFamily="{StaticResource InterMedium}",
                                 FontSize=22
                            }
                        },
                    }
                };
                var grade_grid = new Grid
                {
                    RowSpacing = 10,
                    ColumnSpacing = 8,
                    Margin = new Thickness(5),
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                var grade_rowcount = (int)Math.Ceiling(((double)Grades.Count) / 2);
                for (int i = 0; i < grade_rowcount; i++)
                {
                    grade_grid.RowDefinitions.Add(new RowDefinition { Height = 35 });
                }
                grade_grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                grade_grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                var grade_Index = 0;
                for (int rowIndex = 0; rowIndex < grade_rowcount; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < 2; columnIndex++)
                    {
                        if (grade_Index >= Grades.Count)
                        {
                            break;
                        }
                        var grade = Grades[grade_Index];
                        if (Grades.Count >= grade_Index)
                        {
                            var frame = new Frame
                            {
                                OutlineColor = Color.FromHex("#50555C"),
                                HasShadow = false,
                                Padding = new Thickness(0),
                                Content = new Label
                                {
                                    Text = grade,
                                    VerticalOptions = LayoutOptions.Center,
                                    HorizontalOptions = LayoutOptions.Center
                                }
                            };
                            Binding frameColorBinding = new Binding("SelectedProductGrade");
                            frameColorBinding.Converter = FrameColorConverter;
                            frameColorBinding.ConverterParameter = grade;
                            frame.SetBinding(BackgroundColorProperty, frameColorBinding);
                            Binding lblColorBinding = new Binding("SelectedProductGrade");
                            lblColorBinding.Converter = LabelColorConverter;
                            lblColorBinding.ConverterParameter = grade;
                            (frame.Children[0] as Label).SetBinding(Label.TextColorProperty, lblColorBinding);
                            var tapGestureRecognizer = new TapGestureRecognizer();
                            tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, "ProductGradeSelectedCommand");
                            tapGestureRecognizer.CommandParameter = grade;
                            frame.GestureRecognizers.Add(tapGestureRecognizer);
                            grade_grid.Children.Add(frame, columnIndex, rowIndex);
                        }
                        grade_Index += 1;
                    }
                }
                stack.Children.Add(grade_grid);

                var Size = (BindingContext as ProductsPageViewModel).ProductList.Select(x => x.Menu_3_Selection).Distinct().ToList();
                var sizeFrame = new Frame
                {
                    HasShadow = false,
                    OutlineColor = Color.Gray,
                    HeightRequest = 35,
                    Padding = new Thickness(15, 0, 0, 0),
                    CornerRadius = 10,
                    Content = new Label
                    {
                        Text = "3. Select Product Size",
                        TextColor = Color.FromHex("#FF6600"),
                        FontFamily = "{StaticResource InterMedium}",
                        FontSize = 22
                    }
                };
                var size_grid = new Grid
                {
                    RowSpacing = 10,
                    ColumnSpacing = 8,
                    Margin = new Thickness(5),
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                var size_rowcount = (int)Math.Ceiling(((double)Size.Count) / 2);
                for (int i = 0; i < size_rowcount; i++)
                {
                    size_grid.RowDefinitions.Add(new RowDefinition { Height = 35 });
                }
                size_grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                size_grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                var size_Index = 0;
                for (int rowIndex = 0; rowIndex < size_rowcount; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < 2; columnIndex++)
                    {
                        if (size_Index >= Size.Count)
                        {
                            break;
                        }
                        var size = Size[size_Index];
                        if (Size.Count >= size_Index)
                        {
                            var frame = new Frame
                            {
                                OutlineColor = Color.FromHex("#50555C"),
                                HasShadow = false,
                                Padding = new Thickness(0),
                                Content = new Label
                                {
                                    Text = size,
                                    VerticalOptions = LayoutOptions.Center,
                                    HorizontalOptions = LayoutOptions.Center
                                }
                            };
                            Binding frameColorBinding = new Binding("SelectedProductSize");
                            frameColorBinding.Converter = FrameColorConverter;
                            frameColorBinding.ConverterParameter = size;
                            frame.SetBinding(BackgroundColorProperty, frameColorBinding);
                            Binding lblColorBinding = new Binding("SelectedProductSize");
                            lblColorBinding.Converter = LabelColorConverter;
                            lblColorBinding.ConverterParameter = size;
                            (frame.Children[0] as Label).SetBinding(Label.TextColorProperty, lblColorBinding);
                            var tapGestureRecognizer = new TapGestureRecognizer();
                            tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, "ProductSizeSelectedCommand");
                            tapGestureRecognizer.CommandParameter = size;
                            frame.GestureRecognizers.Add(tapGestureRecognizer);
                            size_grid.Children.Add(frame, columnIndex, rowIndex);
                        }
                        size_Index += 1;
                    }
                }
                stack.Children.Add(sizeFrame);
                stack.Children.Add(size_grid);

                var PinSizes = (BindingContext as ProductsPageViewModel).ProductList.Select(x => x.Menu_4_Selection).Distinct().ToList();
                var pinFrame = new Frame
                {
                    HasShadow = false,
                    OutlineColor = Color.Gray,
                    HeightRequest = 35,
                    Padding = new Thickness(15, 0, 0, 0),
                    CornerRadius = 10,
                    Content = new Label
                    {
                        Text = "4. Select Pin Size",
                        TextColor = Color.FromHex("#FF6600"),
                        FontFamily = "{StaticResource InterMedium}",
                        FontSize = 22
                    }
                };
                var pin_grid = new Grid
                {
                    RowSpacing = 10,
                    ColumnSpacing = 8,
                    Margin = new Thickness(5),
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                var pin_rowcount = (int)Math.Ceiling(((double)PinSizes.Count) / 2);
                var pin_columncount = (int)Math.Ceiling(((double)PinSizes.Count) / 2);
                for (int i = 0; i < pin_rowcount; i++)
                {
                    pin_grid.RowDefinitions.Add(new RowDefinition { Height = 35 });
                }
                pin_grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                pin_grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                var pin_Index = 0;
                for (int rowIndex = 0; rowIndex < pin_rowcount; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < 2; columnIndex++)
                    {
                        if (pin_Index >= PinSizes.Count)
                        {
                            break;
                        }
                        var pinsize = PinSizes[pin_Index];
                        if (PinSizes.Count >= pin_Index)
                        {
                            var frame = new Frame
                            {
                                OutlineColor = Color.FromHex("#50555C"),
                                HasShadow = false,
                                Padding = new Thickness(0),
                                Content = new Label
                                {
                                    Text = pinsize,
                                    VerticalOptions = LayoutOptions.Center,
                                    HorizontalOptions = LayoutOptions.Center
                                }
                            };
                            Binding frameColorBinding = new Binding("SelectedProductPinSize");
                            frameColorBinding.Converter = FrameColorConverter;
                            frameColorBinding.ConverterParameter = pinsize;
                            frame.SetBinding(BackgroundColorProperty, frameColorBinding);
                            Binding lblColorBinding = new Binding("SelectedProductPinSize");
                            lblColorBinding.Converter = LabelColorConverter;
                            lblColorBinding.ConverterParameter = pinsize;
                            (frame.Children[0] as Label).SetBinding(Label.TextColorProperty, lblColorBinding);
                            var tapGestureRecognizer = new TapGestureRecognizer();
                            tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, "ProductPinSizeSelectedCommand");
                            tapGestureRecognizer.CommandParameter = pinsize;
                            frame.GestureRecognizers.Add(tapGestureRecognizer);
                            pin_grid.Children.Add(frame, columnIndex, rowIndex);
                        }
                        pin_Index += 1;
                    }
                }
                stack.Children.Add(pinFrame);
                stack.Children.Add(pin_grid);

                var quantityFrame = new Frame
                {
                    HasShadow = false,
                    OutlineColor = Color.Gray,
                    HeightRequest = 35,
                    Padding = new Thickness(15, 0, 0, 0),
                    CornerRadius = 10,
                    Content = new Label
                    {
                        Text = "5. Select Quantity",
                        TextColor = Color.FromHex("#FF6600"),
                        FontFamily = "{StaticResource InterMedium}",
                        FontAttributes = FontAttributes.Bold,
                        FontSize = 22
                    }
                };
                var quantityStack = new StackLayout
                {
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    Orientation = StackOrientation.Horizontal
                };
                var minus_frame = new Frame
                {
                    BackgroundColor = Color.FromHex("#50555C"),
                    Padding = new Thickness(0),
                    HeightRequest = 35,
                    WidthRequest = 35,
                    HasShadow = false,
                    Content = new Label
                    {
                        Text = "-",
                        FontFamily = "{StaticResource InterBold}",
                        TextColor = Color.White,
                        FontSize = 22,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    }
                };
                var quantityValue_frame = new Frame
                {
                    BackgroundColor = Color.FromHex("White"),
                    OutlineColor = Color.LightGray,
                    Padding = new Thickness(0),
                    HeightRequest = 35,
                    WidthRequest = 35,
                    HasShadow = false,
                    Content = new Label
                    {
                        Text = "123",
                        FontFamily = "{StaticResource InterBold}",
                        TextColor = Color.Black,
                        FontSize = 22,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    }
                };
                var plus_frame = new Frame
                {
                    BackgroundColor = Color.FromHex("#50555C"),
                    Padding = new Thickness(0),
                    HeightRequest = 35,
                    WidthRequest = 35,
                    HasShadow = false,
                    Content = new Label
                    {
                        Text = "+",
                        FontFamily = "{StaticResource InterBold}",
                        TextColor = Color.White,
                        FontSize = 22,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    }
                };
                quantityStack.Children.Add(minus_frame);
                quantityStack.Children.Add(quantityValue_frame);
                quantityStack.Children.Add(plus_frame);
                stack.Children.Add(quantityFrame);
                stack.Children.Add(quantityStack);


                if (Counter == 0)
                {
                    InnerStack.Children.Add(stack);
                    Counter = 1;
                }
                else
                {
                    InnerStack.Children.RemoveAt(0);
                    InnerStack.Children.Add(stack);
                }
            }
            catch (Exception e)
            {

            }
        }
        public void CreatePolishedRodFilters()
        {
            SelectedFrameBgColor FrameColorConverter = new SelectedFrameBgColor();
            SelectedLabelColorConverter LabelColorConverter = new SelectedLabelColorConverter();
            try
            {
                var Grades = (BindingContext as ProductsPageViewModel).ProductList.Select(x => x.Menu_2_Selection).Distinct().ToList();
                var stack = new StackLayout
                {
                    Children =
                    {
                        new Frame
                        {
                            HasShadow=false ,
                            OutlineColor=Color.Gray,
                            HeightRequest=35,
                            Padding=new Thickness(15,0,0,0),
                            CornerRadius=10 ,
                            Content=new Label
                            {
                                Text="2. Select Product Grade",
                                TextColor=Color.FromHex("#FF6600") ,
                                FontFamily="{StaticResource InterMedium}",
                                 FontSize=22
                            }
                        },
                    }
                };
                var grade_grid = new Grid
                {
                    RowSpacing = 10,
                    ColumnSpacing = 8,
                    Margin = new Thickness(5),
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                var grade_rowcount = (int)Math.Ceiling(((double)Grades.Count) / 2);
                for (int i = 0; i < grade_rowcount; i++)
                {
                    grade_grid.RowDefinitions.Add(new RowDefinition { Height = 35 });
                }
                grade_grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                grade_grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                var grade_Index = 0;
                for (int rowIndex = 0; rowIndex < grade_rowcount; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < 2; columnIndex++)
                    {
                        if (grade_Index >= Grades.Count)
                        {
                            break;
                        }
                        var grade = Grades[grade_Index];
                        if (Grades.Count >= grade_Index)
                        {
                            var frame = new Frame
                            {
                                OutlineColor = Color.FromHex("#50555C"),
                                HasShadow = false,
                                Padding = new Thickness(0),
                                Content = new Label
                                {
                                    Text = grade,
                                    VerticalOptions = LayoutOptions.Center,
                                    HorizontalOptions = LayoutOptions.Center
                                }
                            };
                            Binding frameColorBinding = new Binding("SelectedProductGrade");
                            frameColorBinding.Converter = FrameColorConverter;
                            frameColorBinding.ConverterParameter = grade;
                            frame.SetBinding(BackgroundColorProperty, frameColorBinding);
                            Binding lblColorBinding = new Binding("SelectedProductGrade");
                            lblColorBinding.Converter = LabelColorConverter;
                            lblColorBinding.ConverterParameter = grade;
                            (frame.Children[0] as Label).SetBinding(Label.TextColorProperty, lblColorBinding);
                            var tapGestureRecognizer = new TapGestureRecognizer();
                            tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, "ProductGradeSelectedCommand");
                            tapGestureRecognizer.CommandParameter = grade;
                            frame.GestureRecognizers.Add(tapGestureRecognizer);
                            grade_grid.Children.Add(frame, columnIndex, rowIndex);
                        }
                        grade_Index += 1;
                    }
                }
                stack.Children.Add(grade_grid);

                var Size = (BindingContext as ProductsPageViewModel).ProductList.Select(x => x.Menu_3_Selection).Distinct().ToList();
                var sizeFrame = new Frame
                {
                    HasShadow = false,
                    OutlineColor = Color.Gray,
                    HeightRequest = 35,
                    Padding = new Thickness(15, 0, 0, 0),
                    CornerRadius = 10,
                    Content = new Label
                    {
                        Text = "3. Select Product Size",
                        TextColor = Color.FromHex("#FF6600"),
                        FontFamily = "{StaticResource InterMedium}",
                        FontSize = 22
                    }
                };
                var size_grid = new Grid
                {
                    RowSpacing = 10,
                    ColumnSpacing = 8,
                    Margin = new Thickness(5),
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                var size_rowcount = (int)Math.Ceiling(((double)Size.Count) / 2);
                for (int i = 0; i < size_rowcount; i++)
                {
                    size_grid.RowDefinitions.Add(new RowDefinition { Height = 35 });
                }
                size_grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                size_grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                var size_Index = 0;
                for (int rowIndex = 0; rowIndex < size_rowcount; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < 2; columnIndex++)
                    {
                        if (size_Index >= Size.Count)
                        {
                            break;
                        }
                        var size = Size[size_Index];
                        if (Size.Count >= size_Index)
                        {
                            var frame = new Frame
                            {
                                OutlineColor = Color.FromHex("#50555C"),
                                HasShadow = false,
                                Padding = new Thickness(0),
                                Content = new Label
                                {
                                    Text = size,
                                    VerticalOptions = LayoutOptions.Center,
                                    HorizontalOptions = LayoutOptions.Center
                                }
                            };
                            Binding frameColorBinding = new Binding("SelectedProductSize");
                            frameColorBinding.Converter = FrameColorConverter;
                            frameColorBinding.ConverterParameter = size;
                            frame.SetBinding(BackgroundColorProperty, frameColorBinding);
                            Binding lblColorBinding = new Binding("SelectedProductSize");
                            lblColorBinding.Converter = LabelColorConverter;
                            lblColorBinding.ConverterParameter = size;
                            (frame.Children[0] as Label).SetBinding(Label.TextColorProperty, lblColorBinding);
                            var tapGestureRecognizer = new TapGestureRecognizer();
                            tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, "ProductSizeSelectedCommand");
                            tapGestureRecognizer.CommandParameter = size;
                            frame.GestureRecognizers.Add(tapGestureRecognizer);
                            size_grid.Children.Add(frame, columnIndex, rowIndex);
                        }
                        size_Index += 1;
                    }
                }
                stack.Children.Add(sizeFrame);
                stack.Children.Add(size_grid);

                var PinSizes = (BindingContext as ProductsPageViewModel).ProductList.Select(x => x.Menu_4_Selection).Distinct().ToList();
                var pinFrame = new Frame
                {
                    HasShadow = false,
                    OutlineColor = Color.Gray,
                    HeightRequest = 35,
                    Padding = new Thickness(15, 0, 0, 0),
                    CornerRadius = 10,
                    Content = new Label
                    {
                        Text = "4. Select Pin Size",
                        TextColor = Color.FromHex("#FF6600"),
                        FontFamily = "{StaticResource InterMedium}",
                        FontSize = 22
                    }
                };
                var pin_grid = new Grid
                {
                    RowSpacing = 10,
                    ColumnSpacing = 8,
                    Margin = new Thickness(5),
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                var pin_rowcount = (int)Math.Ceiling(((double)PinSizes.Count) / 2);
                var pin_columncount = (int)Math.Ceiling(((double)PinSizes.Count) / 2);
                for (int i = 0; i < pin_rowcount; i++)
                {
                    pin_grid.RowDefinitions.Add(new RowDefinition { Height = 35 });
                }
                pin_grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                pin_grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                var pin_Index = 0;
                for (int rowIndex = 0; rowIndex < pin_rowcount; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < 2; columnIndex++)
                    {
                        if (pin_Index >= PinSizes.Count)
                        {
                            break;
                        }
                        var pinsize = PinSizes[pin_Index];
                        if (PinSizes.Count >= pin_Index)
                        {
                            var frame = new Frame
                            {
                                OutlineColor = Color.FromHex("#50555C"),
                                HasShadow = false,
                                Padding = new Thickness(0),
                                Content = new Label
                                {
                                    Text = pinsize,
                                    VerticalOptions = LayoutOptions.Center,
                                    HorizontalOptions = LayoutOptions.Center
                                }
                            };
                            Binding frameColorBinding = new Binding("SelectedProductPinSize");
                            frameColorBinding.Converter = FrameColorConverter;
                            frameColorBinding.ConverterParameter = pinsize;
                            frame.SetBinding(BackgroundColorProperty, frameColorBinding);
                            Binding lblColorBinding = new Binding("SelectedProductPinSize");
                            lblColorBinding.Converter = LabelColorConverter;
                            lblColorBinding.ConverterParameter = pinsize;
                            (frame.Children[0] as Label).SetBinding(Label.TextColorProperty, lblColorBinding);
                            var tapGestureRecognizer = new TapGestureRecognizer();
                            tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, "ProductPinSizeSelectedCommand");
                            tapGestureRecognizer.CommandParameter = pinsize;
                            frame.GestureRecognizers.Add(tapGestureRecognizer);
                            pin_grid.Children.Add(frame, columnIndex, rowIndex);
                        }
                        pin_Index += 1;
                    }
                }
                stack.Children.Add(pinFrame);
                stack.Children.Add(pin_grid);

                var Lengths = (BindingContext as ProductsPageViewModel).ProductList.Select(x => x.Menu_5_Selection).Distinct().ToList();
                var lengthFrame = new Frame
                {
                    HasShadow = false,
                    OutlineColor = Color.Gray,
                    HeightRequest = 35,
                    Padding = new Thickness(15, 0, 0, 0),
                    CornerRadius = 10,
                    Content = new Label
                    {
                        Text = "5. Select Product Length",
                        TextColor = Color.FromHex("#FF6600"),
                        FontFamily = "{StaticResource InterMedium}",
                        FontSize = 22
                    }
                };
                var length_grid = new Grid
                {
                    RowSpacing = 10,
                    ColumnSpacing = 8,
                    Margin = new Thickness(5),
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                var length_rowcount = (int)Math.Ceiling(((double)Lengths.Count) / 2);
                var length_columncount = (int)Math.Ceiling(((double)Lengths.Count) / 2);
                for (int i = 0; i < pin_rowcount; i++)
                {
                    length_grid.RowDefinitions.Add(new RowDefinition { Height = 35 });
                }
                length_grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                length_grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                var length_Index = 0;
                for (int rowIndex = 0; rowIndex < length_rowcount; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < 2; columnIndex++)
                    {
                        if (length_Index >= Lengths.Count)
                        {
                            break;
                        }
                        var length = Lengths[length_Index];
                        if (Lengths.Count >= length_Index)
                        {
                            var frame = new Frame
                            {
                                OutlineColor = Color.FromHex("#50555C"),
                                HasShadow = false,
                                Padding = new Thickness(0),
                                Content = new Label
                                {
                                    Text = length,
                                    VerticalOptions = LayoutOptions.Center,
                                    HorizontalOptions = LayoutOptions.Center
                                }
                            };
                            Binding frameColorBinding = new Binding("SelectedProductLength");
                            frameColorBinding.Converter = FrameColorConverter;
                            frameColorBinding.ConverterParameter = length;
                            frame.SetBinding(BackgroundColorProperty, frameColorBinding);
                            Binding lblColorBinding = new Binding("SelectedProductLength");
                            lblColorBinding.Converter = LabelColorConverter;
                            lblColorBinding.ConverterParameter = length;
                            (frame.Children[0] as Label).SetBinding(Label.TextColorProperty, lblColorBinding);
                            var tapGestureRecognizer = new TapGestureRecognizer();
                            tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, "ProductLengthSelectedCommand");
                            tapGestureRecognizer.CommandParameter = length;
                            frame.GestureRecognizers.Add(tapGestureRecognizer);
                            length_grid.Children.Add(frame, columnIndex, rowIndex);
                        }
                        length_Index += 1;
                    }
                }
                stack.Children.Add(lengthFrame);
                stack.Children.Add(length_grid);


                var quantityFrame = new Frame
                {
                    HasShadow = false,
                    OutlineColor = Color.Gray,
                    HeightRequest = 35,
                    Padding = new Thickness(15, 0, 0, 0),
                    CornerRadius = 10,
                    Content = new Label
                    {
                        Text = "6. Select Quantity",
                        TextColor = Color.FromHex("#FF6600"),
                        FontFamily = "{StaticResource InterMedium}",
                        FontSize = 22
                    }
                };
                var quantityStack = new StackLayout
                {
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    Orientation = StackOrientation.Horizontal
                };
                var minus_frame = new Frame
                {
                    BackgroundColor = Color.FromHex("#50555C"),
                    Padding = new Thickness(0),
                    HeightRequest = 35,
                    WidthRequest = 35,
                    HasShadow = false,
                    Content = new Label
                    {
                        Text = "-",
                        FontFamily = "{StaticResource InterBold}",
                        TextColor = Color.White,
                        FontSize = 22,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    }
                };
                var quantityValue_frame = new Frame
                {
                    BackgroundColor = Color.FromHex("White"),
                    OutlineColor = Color.LightGray,
                    Padding = new Thickness(0),
                    HeightRequest = 35,
                    WidthRequest = 35,
                    HasShadow = false,
                    Content = new Label
                    {
                        Text = "123",
                        FontFamily = "{StaticResource InterBold}",
                        TextColor = Color.Black,
                        FontSize = 22,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    }
                };
                var plus_frame = new Frame
                {
                    BackgroundColor = Color.FromHex("#50555C"),
                    Padding = new Thickness(0),
                    HeightRequest = 35,
                    WidthRequest = 35,
                    HasShadow = false,
                    Content = new Label
                    {
                        Text = "+",
                        FontFamily = "{StaticResource InterBold}",
                        TextColor = Color.White,
                        FontSize = 22,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    }
                };
                quantityStack.Children.Add(minus_frame);
                quantityStack.Children.Add(quantityValue_frame);
                quantityStack.Children.Add(plus_frame);
                stack.Children.Add(quantityFrame);
                stack.Children.Add(quantityStack);


                if (Counter == 0)
                {
                    InnerStack.Children.Add(stack);
                    Counter = 1;
                }
                else
                {
                    InnerStack.Children.RemoveAt(0);
                    InnerStack.Children.Add(stack);
                }
            }
            catch (Exception e)
            {

            }
        }
        public void CreateButtons()
        {
            var AddBtn = new Button
            {
                Text = "Add Selected Item to Order",
                FontFamily = "{StaticResource RobotoRegular}",
                TextColor = Color.White,
                TextTransform = TextTransform.None,
                Margin = new Thickness(0, 20, 0, 5),
                BackgroundColor = Color.FromHex("#FF6600"),
                CornerRadius = 5,
                Padding = new Thickness(1),
                HeightRequest = 40
            };
            var DeleteBtn = new Button
            {
                Text = "Delete and Return",
                FontFamily = "{StaticResource RobotoRegular}",
                TextColor = Color.White,
                TextTransform = TextTransform.None,
                Margin = new Thickness(0, 20, 0, 5),
                BackgroundColor = Color.FromHex("#FF6600"),
                CornerRadius = 5,
                Padding = new Thickness(1),
                HeightRequest = 40
            };
            DeleteBtn.SetBinding(Button.CommandProperty, "DeleteAndReturnBtnCommand");
        }
    }
}

