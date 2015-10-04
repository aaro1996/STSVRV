using UnityEngine;
using System.Collections;

public class AaronSearchByBuildingScript : MonoBehaviour
{
    public enum building { None_Found = -1, Brookings_Hall, Lopata_Hall, Olin_Library, Danforth_University_Center, Mallinckrodt, Lab_Sci, Graham_Chapel };
    public building[] myFoundBuildings;
    public static int NUM_BUILDINGS_RETURNED_IN_SEARCH = 4;
    public static string[] BUILDINGS = { "Brookings Hall", "Lopata Hall", "Olin Library", "Danforth University Center", "Mallinckrodt", "Lab_Sci", "Graham Chapel" };
    // Use this for initialization
    void Start()
    {
        myFoundBuildings = new building[NUM_BUILDINGS_RETURNED_IN_SEARCH];
        for (int i = 0; i < NUM_BUILDINGS_RETURNED_IN_SEARCH; ++i)
            myFoundBuildings[i] = (building)(-1);
    }

    // Update is called once per frame
    void Update()
    {

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
            s = BUILDINGS[i];
            if (System.Text.RegularExpressions.Regex.IsMatch(s, searchString, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
                myFoundBuildings[buildingsAdded] = (building)i;
                buildingsAdded++;
            }
        }
    }

}
