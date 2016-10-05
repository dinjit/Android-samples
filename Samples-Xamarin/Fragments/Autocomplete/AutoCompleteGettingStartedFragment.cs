﻿using System;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using Com.Telerik.Widget.Autocomplete;


namespace Samples
{
	public class AutoCompleteGettingStartedFragment : Android.Support.V4.App.Fragment, ExampleFragment
	{
		private RadAutoCompleteTextView autocomplete;
		private AutoCompleteAdapter adapter;
		private List<String> data;

		public AutoCompleteGettingStartedFragment() : base()
		{
			this.data = new List<string>() { "Australia", "Albania","Austria", "Argentina", "Maldives","Bulgaria","Belgium","Cyprus","Italy","Japan",
										"Denmark","Finland","France","Germany","Greece","Hungary","Ireland",
										"Latvia","Luxembourg","Macedonia","Moldova","Monaco","Netherlands","Norway",
										"Poland","Romania","Russia","Sweden","Slovenia","Slovakia","Turkey","Ukraine",
										"Vatican City", "Chad", "China", "Chile" };
		}

		public string Title()
		{
			return "Getting Started";
		}

		public override Android.Views.View OnCreateView(Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Android.OS.Bundle savedInstanceState)
		{
			View rootView = inflater.Inflate(Resource.Layout.fragment_autocomplete_getting_started,container,false);
			this.autocomplete = (RadAutoCompleteTextView)rootView.FindViewById(Resource.Id.autocmp);

			this.autocomplete.SuggestMode = SuggestMode.Suggest;
			this.autocomplete.DisplayMode = DisplayMode.Plain;

			this.adapter = new AutoCompleteAdapter(this.Context, this.GetTokenObjects(), Java.Lang.Integer.ValueOf(Resource.Layout.suggestion_item_layout));
			this.adapter.CompletionMode = CompletionMode.StartsWith;
			this.autocomplete.Adapter = this.adapter;

			Display display = this.Activity.WindowManager.DefaultDisplay;
			int height = display.Height;
			this.autocomplete.SuggestionViewHeight = height / 4;

			this.SetButtonActions(rootView);

			return rootView;
		}

		private List<TokenModel> GetTokenObjects()
		{
			List<TokenModel> feedData = new List<TokenModel>();
			for (int i = 0; i < this.data.Count; i++)
			{
				TokenModel token = new TokenModel(this.data[i], null);
				feedData.Add(token);
			}

			return feedData;
		}

		private void SetButtonActions(View rootView)
		{
			Button btnSuggest = (Button)rootView.FindViewById(Resource.Id.suggestButton);
			btnSuggest.Click += (object sender, EventArgs e) =>
			{
				this.autocomplete.SuggestMode = SuggestMode.Suggest;
			};

			Button btnSuggestAppend = (Button)rootView.FindViewById(Resource.Id.suggestAppendButton);
			btnSuggestAppend.Click += (object sender, EventArgs e) =>
			{
				this.autocomplete.SuggestMode = SuggestMode.SuggestAppend;
			};

			Button btnAppend = (Button)rootView.FindViewById(Resource.Id.appendButton);
			btnAppend.Click += (object sender, EventArgs e) =>
			{
				this.autocomplete.SuggestMode = SuggestMode.Append;
			};

			Button btnStartsWith = (Button)rootView.FindViewById(Resource.Id.startsWithButton);
			btnStartsWith.Click += (object sender, EventArgs e) =>
			{
				this.autocomplete.Adapter.CompletionMode = CompletionMode.StartsWith;
			};

			Button btnContains = (Button)rootView.FindViewById(Resource.Id.containsButton);
			btnContains.Click += (object sender, EventArgs e) =>
			{
				this.autocomplete.Adapter.CompletionMode = CompletionMode.Contains;
			};

			Button btnTokens = (Button)rootView.FindViewById(Resource.Id.tokens_mode_btn);
			btnTokens.Click += (object sender, EventArgs e) =>
			{
				this.autocomplete.DisplayMode = DisplayMode.Tokens;
			};

			Button btnPlain = (Button)rootView.FindViewById(Resource.Id.plain_mode_btn);
			btnPlain.Click += (object sender, EventArgs e) =>
			{
				this.autocomplete.DisplayMode = DisplayMode.Plain;
			};

		}
	}
}
