using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DynamicLayoutAndTransitions
{
	public class FoodModel : INotifyPropertyChanged
	{
		private List<FoodModelItem> masterList = new List<FoodModelItem>()
			{
				new FoodModelItem() { Name = "Chocolate Cake", IsLiked = true, Order = 10 },
				new FoodModelItem() { Name = "Brussels Sprouts", IsLiked = false, Order = 11 },
				new FoodModelItem() { Name = "Mocha Ice Cream", IsLiked = true, Order = 12 },
				new FoodModelItem() { Name = "Asparagus", IsLiked = false, Order = 13 },
				new FoodModelItem() { Name = "Sushi", IsLiked = true, Order = 14 },
				new FoodModelItem() { Name = "Cilantro", IsLiked = false, Order = 15 },
				new FoodModelItem() { Name = "Diet Coke", IsLiked = true, Order = 16 },
				new FoodModelItem() { Name = "Tequila", IsLiked = false, Order = 17 },
				new FoodModelItem() { Name = "Habanero Peppers", IsLiked = true, Order = 18 },
				new FoodModelItem() { Name = "Lutefisk", IsLiked = false, Order = 19 },
				new FoodModelItem() { Name = "Sauerkraut", IsLiked = true, Order = 20 },
				new FoodModelItem() { Name = "Haggis", IsLiked = false, Order = 21 }
			};
		
		private ObservableCollection<FoodModelItem> foodsILike = new ObservableCollection<FoodModelItem>();
		private ObservableCollection<FoodModelItem> foodsIHate = new ObservableCollection<FoodModelItem>();
		private double numberOfItems;
		
		public ObservableCollection<FoodModelItem> FoodsILike { get { return this.foodsILike; } }
		public ObservableCollection<FoodModelItem> FoodsIHate { get { return this.foodsIHate; } }
		public double MaxNumberOfItems { get { return this.masterList.Count; } }
		public double NumberOfItems
		{
			get { return this.numberOfItems; }
			set { this.numberOfItems = value; this.OnPropertyChanged("NumberOfItems"); this.UpdateCollections(); }
		}

		public FoodModel()
		{
			this.numberOfItems = this.masterList.Count;
			
			foreach (FoodModelItem item in this.masterList)
			{
				item.PropertyChanged += OnItemPropertyChanged;
			}
			
			this.UpdateCollections();
		}

		private void UpdateCollections()
		{
			this.UpdateObservableCollection(this.FoodsILike, true);
			this.UpdateObservableCollection(this.FoodsIHate, false);
		}
		
		private void UpdateObservableCollection(ObservableCollection<FoodModelItem> collection, bool filter)
		{
			int index = 0;
			int collectionIndex = 0;
			
			foreach(FoodModelItem item in this.masterList)
			{
				bool itemIsAvailable = collectionIndex < this.NumberOfItems;
				
				if (item.IsLiked == filter && itemIsAvailable)
				{
					if (index >= collection.Count || collection[index] != item)
					{
						if (collection.Contains(item))
						{
							collection.Remove(item); // don't have it in place twice
						}
						collection.Insert(index, item);
					}
					index++;
				}
				else
				{
					if (index < collection.Count && collection[index] == item)
					{
						collection.RemoveAt(index);
					}
				}
				
				collectionIndex++;
			}
			
			while (collection.Count > index)
			{
				collection.RemoveAt(index);
			}
		}

        private void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
			this.UpdateCollections();
        }
		
		public void SortOriginal()
		{
			this.masterList.Sort(new Comparison<FoodModelItem>(delegate(FoodModelItem a, FoodModelItem b) { return (int)(a.Order - b.Order); }));
			this.UpdateCollections();
		}

		public void SortAlphabetical()
		{
			this.masterList.Sort(new Comparison<FoodModelItem>(delegate(FoodModelItem a, FoodModelItem b) { return String.Compare(a.Name, b.Name); }));
			this.UpdateCollections();
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}

	public class FoodModelItem : INotifyPropertyChanged
	{
		private string name = string.Empty;
		public string Name
		{
			get { return this.name; }
			set { if (this.name != value) { this.name = value; this.OnPropertyChanged("Name"); } }
		}

		private bool isLiked = false;
		public bool IsLiked
		{
			get { return this.isLiked; }
			set { if (this.isLiked != value) { this.isLiked = value; this.OnPropertyChanged("IsLiked"); } }
		}

		private double order = 0;
		public double Order
		{
			get { return this.order; }
			set { if (this.order != value) { this.order = value; this.OnPropertyChanged("Order"); } }
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}