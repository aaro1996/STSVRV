using UnityEngine;
using System.Collections;

public class buildingWithThingsInside {
        public string[] stuffInside;
        public buildingWithThingsInside(string[] inputStuffInside)
        {
            this.stuffInside = inputStuffInside;
        }
};
public class AaronSearchByDesireScript : MonoBehaviour {
    public enum building { None_Found = -1, Brookings_Hall, Lopata_Hall, Olin_Library, Danforth_University_Center, Mallinckrodt, Lab_Sci, Graham_Chapel };
    public building[] myFoundBuildings;
    public static int NUM_BUILDINGS_RETURNED_IN_SEARCH = 4;
    //This is declaring what is in buildings
    public static string[] Brookings = {"Student Financial Services", "Office of Undergraduate Admissions"};
    public static string[] Lopata_Hall = {"Computer Labs", "Printers", "Food Court"};
    public static string[] Olin_Library = {};
    public static string[] Danforth_University_Center = {};
    public static string[] Mallinckrodt = {};
    public static string[] Lab_Sci = {};
    public static string[] Graham_Chapel = {};

    public static buildingWithThingsInside[] BUILDINGS = {new buildingWithThingsInside(Brookings),
                                           new buildingWithThingsInside(Lopata_Hall),
                                           new buildingWithThingsInside(Olin_Library),
                                           new buildingWithThingsInside(Danforth_University_Center),
                                           new buildingWithThingsInside(Mallinckrodt),
                                           new buildingWithThingsInside(Lab_Sci),
                                           new buildingWithThingsInside(Graham_Chapel)};	
    // Use this for initialization
	void Start () {
        myFoundBuildings = new building[NUM_BUILDINGS_RETURNED_IN_SEARCH];
        for (int i = 0; i < NUM_BUILDINGS_RETURNED_IN_SEARCH; ++i)
            myFoundBuildings[i] = (building)(-1);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void Search(string searchString)
    {
        int buildingsAdded = 0;
        string s;
        for (int i = 0; i < BUILDINGS.Length; ++i)
        {
            if (buildingsAdded == NUM_BUILDINGS_RETURNED_IN_SEARCH)
            {
                break;
            }
            for (int j = 0; j < BUILDINGS[i].stuffInside.Length; j++)
            {
                s = BUILDINGS[i].stuffInside[j];
                if (System.Text.RegularExpressions.Regex.IsMatch(s, searchString, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                {
                    myFoundBuildings[buildingsAdded] = (building)i;
                    buildingsAdded++;
                    break;
                }
            }
        }
    }
}

