using System;
using System.Collections.Generic;

namespace ConsoleApp99
{
	class Program
	{
		public static void Main(string[] args)
		{
			var addressBookList = new List<Tuple<string, string, string, string>>{
			Tuple.Create("","","", ""),
			};
			menuText();
			var menuAnswer = int.Parse(Console.ReadLine());

			while (menuAnswer >= 1 && menuAnswer <= 5)
			{
				if (menuAnswer == 1)
				{
					Console.WriteLine("Type in first name,last name , address, mobile number(in that order)");
					var firstName = (Console.ReadLine());
					var lastName = Console.ReadLine();
					var address = (Console.ReadLine());
					var mobileNumber = (Console.ReadLine());
					Console.WriteLine("enter mobile number again");
					var mobileNumber2 = (Console.ReadLine());
					mobileNumber = mobileNumber.Replace(" ", "");
					mobileNumber2 = mobileNumber2.Replace(" ", "");

					if (mobileNumber == mobileNumber2)
					{

						Console.WriteLine("Are you sure you want to do this? Type yes if you do");
						var checkAnswer = (Console.ReadLine());
						var nonUniqueNumberCount = 0;
						foreach (var item in addressBookList)
						{
							if (item.Item4 == mobileNumber)
							{
								nonUniqueNumberCount++;
							}

						}
						if ((checkAnswer == "Yes" || checkAnswer == "yes") && nonUniqueNumberCount == 0)
						{

							var AddressBook = Tuple.Create<string, string, string, string>(lastName, firstName, address, mobileNumber);

							addressBookList.Add(AddressBook);


						}

						else
							Console.WriteLine("Not confirmed or number is already in use");
					}
					else
					{
						Console.WriteLine("your numbers don't match");
					}
					menuText();

					menuAnswer = int.Parse(Console.ReadLine());


				}
				else if (menuAnswer == 2)
				{
					Console.WriteLine("What do you want to change about your most recent entry? " +
						"Type 'name' for editing first and lastname, type 'address' if you want to change address, type number if you are willing to change" +
							 "mobile phone number");
					var answer2 = Console.ReadLine();
					if (answer2 == "name" || answer2 == "Name" || answer2 == "NAME")
					{
						Console.WriteLine("Type new first and last name");
						var newFirstName = Console.ReadLine();
						var newLastName = Console.ReadLine();
						Console.WriteLine("Are you sure you want to do this? Type yes if you do");
						var checkAnswer2 = (Console.ReadLine());
						if (checkAnswer2 == "Yes" || checkAnswer2 == "yes")
						{
							var AddressBookChangedName = Tuple.Create<string, string, string, string>(newLastName, newFirstName, addressBookList[addressBookList.Count - 1].Item3,
							addressBookList[addressBookList.Count - 1].Item4);

							addressBookList[addressBookList.Count - 1] = AddressBookChangedName;
						}
						else
							Console.WriteLine("Not confirmed.");



					}
					else if (answer2 == "address" || answer2 == "Address" || answer2 == "ADDRESS")
					{
						Console.WriteLine("Type new address");
						var newAddress = Console.ReadLine();
						Console.WriteLine("Are you sure you want to do this? Type yes if you do");
						var checkAnswer3 = (Console.ReadLine());
						if (checkAnswer3 == "Yes" || checkAnswer3 == "yes")
						{
							var AddressBookChangedAddress = Tuple.Create<string, string, string, string>(addressBookList[addressBookList.Count - 1].Item1,
							 addressBookList[addressBookList.Count - 1].Item2, newAddress,
							addressBookList[addressBookList.Count - 1].Item4);

							addressBookList[addressBookList.Count - 1] = AddressBookChangedAddress;

						}
						else
							Console.WriteLine("Not confirmed.");



					}
					else if (answer2 == "number" || answer2 == "Number" || answer2 == "NUMBER")
					{
						Console.WriteLine("Type new number");
						var newNumber = (Console.ReadLine());
						newNumber = newNumber.Replace(" ", "");

						Console.WriteLine("Type it again to confirm");
						var numberConfirm = Console.ReadLine();
						numberConfirm = numberConfirm.Replace(" ", "");

						Console.WriteLine("Are you sure you want to do this? Type yes if you do");
						var checkAnswer3 = (Console.ReadLine());
						if (checkAnswer3 == "Yes" || checkAnswer3 == "yes")
						{
							if (newNumber == numberConfirm)
							{
								var AddressBookChangedNumber = Tuple.Create<string, string, string, string>(addressBookList[addressBookList.Count - 1].Item1,
									 addressBookList[addressBookList.Count - 1].Item2, addressBookList[addressBookList.Count - 1].Item3, newNumber)
									;
								addressBookList[addressBookList.Count - 1] = AddressBookChangedNumber;


							}
							else
							{
								Console.WriteLine("numbers dont match");

							}
						}
						else
							Console.WriteLine("Not confirmed.");

					}
					else
					{
						Console.WriteLine("wrong command");
						menuText();
						menuAnswer = int.Parse(Console.ReadLine());

					}
					menuText();
					menuAnswer = int.Parse(Console.ReadLine());
				}
				else if (menuAnswer == 3)
				{
					Console.WriteLine("Are you sure you want to delete your recent entry? Type yes if you are.");
					var menuAnswerConfirm = Console.ReadLine();
					if (menuAnswerConfirm == "yes" || menuAnswerConfirm == "YES" || menuAnswerConfirm == "Yes")
					{
						addressBookList.RemoveAt(addressBookList.Count - 1);
					}
					else
						Console.WriteLine("typo");

					menuText();
					menuAnswer = int.Parse(Console.ReadLine());
				}
				else if (menuAnswer == 4)
				{
					Console.WriteLine("Enter the number you want to search to find input");
					var searchByNumber = Console.ReadLine();
					Console.WriteLine("Enter the number again for confirmation");
					var searchByNumberConfirm = Console.ReadLine();
					searchByNumber = searchByNumber.Replace(" ", "");
					searchByNumberConfirm = searchByNumberConfirm.Replace(" ", "");

					if (searchByNumber == searchByNumberConfirm)

					{
						foreach (var item in addressBookList)
						{
							if (item.Item4 == searchByNumber)
							{
								Console.WriteLine(item);
							}

						}
					}
					menuText();
					menuAnswer = int.Parse(Console.ReadLine());
				}
				else
				{
					Console.WriteLine("Enter the text you want to search to find first or last name. Text musn't have more characters than wanted first or last name ");

					var lastNameSearchList = new List<string>();
					foreach (var item in addressBookList)
					{

						lastNameSearchList.Add(item.Item1);
					}
					var firstNameSearchList = new List<string>();
					foreach (var item in addressBookList)
					{
						firstNameSearchList.Add(item.Item2);
					}


					var nameSearch = Console.ReadLine();
					var lastNameSearchList2 = new List<string>();
					var positionListLastName = new List<int>();

					for (int i = 1; i < lastNameSearchList.Count; i++)
					{
						lastNameSearchList2.Add(lastNameSearchList[i].Substring(0, nameSearch.Length));
					}
					for (int i = 0; i < lastNameSearchList2.Count; i++)
					{
						if (lastNameSearchList2[i] == nameSearch)
						{
							positionListLastName.Add(i + 1);
						}
					}
					var firstNameSearchList2 = new List<string>();
					var positionListFirstName = new List<int>();
					for (int i = 1; i < firstNameSearchList.Count; i++)
					{
						firstNameSearchList2.Add(firstNameSearchList[i].Substring(0, nameSearch.Length));
					}
					for (int i = 0; i < firstNameSearchList2.Count; i++)
					{
						if (firstNameSearchList2[i] == nameSearch)
						{
							positionListFirstName.Add(i + 1);
						}
					}
					for (int i = 0; i < positionListFirstName.Count; i++)
					{
						for (int j = 0; j < positionListLastName.Count; j++)
						{
							if (positionListFirstName[i] != positionListLastName[j] && positionListLastName[j] != positionListFirstName[j])
							{
								positionListLastName.Add(positionListFirstName[i]);
							}
						}

					}
					var addressBookNameSearch = new List<Tuple<string, string, string, string>>{
							Tuple.Create("","","", ""),
					};

					for (int i = 0; i < positionListLastName.Count; i++)
					{
						addressBookNameSearch.Add(addressBookList[positionListLastName[i]]);
					}
					addressBookNameSearch.RemoveAt(0);
					addressBookNameSearch.Sort();
					foreach (var item in addressBookNameSearch)
					{

						Console.WriteLine(item);
					}
					menuText();
					menuAnswer = int.Parse(Console.ReadLine());
				}

			}
			Console.WriteLine("End program");


		}
		static void menuText()
		{
			Console.WriteLine("Choose the action by typing the number which represents the command, press non given number in the menu to stop ");
			Console.WriteLine("1.Add new person to the address book");
			Console.WriteLine("2.Change the name, address or mobile phone number of recently added person in address book");
			Console.WriteLine("3.Delete the person from the address book");
			Console.WriteLine("4.Search the addressbook by mobile phone number");
			Console.WriteLine("5.Search the addressbook by name");
			Console.WriteLine("6.Exit program");
		}
	}
}




