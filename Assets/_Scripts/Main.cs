using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour {

    public Data data;
    public GameObject heroIconPrefab;
    public RectTransform selectedHeroesRect;

    List<Data.Hero> selectedHeroes = new List<Data.Hero>();
    List<GameObject> heroMiniIcons = new List<GameObject>();

    private void OnEnable()
    {
        ItemInGrid.onListsChanged += RefreshSelectedHeroes;
    }

    private void OnDisable()
    {
        ItemInGrid.onListsChanged -= RefreshSelectedHeroes;
    }

    private void Awake()
    {
        data = GetComponent<Data>();
    }

    void RefreshSelectedHeroes ()
    {
        List<Data.Specs> selectedSpecs = new List<Data.Specs>();
        List<Data.Classes> selectedClasses = new List<Data.Classes>();

        List<Data.Hero> heroesBySpec = new List<Data.Hero>();
        List<Data.Hero> heroesByClass = new List<Data.Hero>();

        selectedHeroes.Clear();

        foreach (SpecInGrid sp in SpecInGrid.selectedSpecs)
        {
            selectedSpecs.Add(sp.spec);
            heroesBySpec.AddRange(data.specsDict[sp.spec]);
        }

        foreach (ClassInGrid cl in ClassInGrid.selectedClasses)
        {
            selectedClasses.Add(cl._class);
            heroesByClass.AddRange(data.classesDict[cl._class]);
        }

        // Sort only by classes
        if (heroesBySpec.Count == 0 && heroesByClass.Count > 0)
        {
            selectedHeroes = heroesByClass;
        }

        // Sort only by spec
        if (heroesByClass.Count == 0 && heroesBySpec.Count > 0)
        {
            selectedHeroes = heroesBySpec;
        }

        // For both
        if (heroesBySpec.Count > 0 && heroesByClass.Count > 0)
        {
            IEnumerable<Data.Hero> sequence = heroesBySpec
                .Where(n => selectedClasses.Contains(n._class))
                .Select(n => n);

            selectedHeroes = sequence.ToList();
            // Removing duplicates
            selectedHeroes = selectedHeroes.Distinct().ToList();
        }

        ShowSelectedHeroes();
    }

    void ShowSelectedHeroes ()
    {
        // Clear
        for (int i = 0; i < heroMiniIcons.Count; i++)
        {
            Destroy(heroMiniIcons[i]);
            heroMiniIcons.Remove(heroMiniIcons[i]);
        }

        float _width = selectedHeroesRect.rect.height / 2;
        selectedHeroesRect.GetComponent<GridLayoutGroup>().cellSize = new Vector2(_width, _width);
        foreach (var item in selectedHeroes)
        {
            Debug.Log(item._specs[0].ToString() + item._class.ToString());
            GameObject go = Instantiate(heroIconPrefab, selectedHeroesRect.transform);
            heroMiniIcons.Add(go);
        }
    }
}


