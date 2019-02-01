using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Data : MonoBehaviour {

	public enum Specs { Orc, Beast, Ogre, Undead, Goblin, Troll, Elf, Elemental, Human, Demon, Naga, Dwarf, Dragon};
    public enum Classes { Warrior, Druid, Mage, Hunter, Assassin, Mech, Shaman, Knight, DemonHunter, Warlock };

    public struct Hero
    {
        public List<Specs> _specs;
        public Classes _class;
        public int price;
        public Sprite miniIcon;
    }

    public List<Hero> allHeroes = new List<Hero>();

    public Dictionary<Specs, List<Hero>> specsDict = new Dictionary<Specs, List<Hero>> ();
    public Dictionary<Classes, List<Hero>> classesDict = new Dictionary<Classes, List<Hero>>();

    private void Awake()
    {
        // TODO: read from JSON
        List<Specs> sps = Enum.GetValues(typeof(Specs)).Cast<Specs>().ToList();
        List<Classes> cls = Enum.GetValues(typeof(Classes)).Cast<Classes>().ToList();
        for (int i = 0; i < 40; i++)
        {
            Hero hero = new Hero();
            hero._specs = new List<Specs>();
            hero._specs.Add(sps[UnityEngine.Random.Range(0, sps.Count)]);
            hero._class = cls[UnityEngine.Random.Range(0, cls.Count)];
            hero.price = 3;
            hero.miniIcon = null;

            allHeroes.Add(hero);
        }
        //

        foreach (Specs spec in Enum.GetValues(typeof(Specs)))
        {
            specsDict.Add(spec, new List<Hero>());
        }

        foreach (Classes _class in Enum.GetValues(typeof(Classes)))
        {
            classesDict.Add(_class, new List<Hero>());
        }

        foreach (Hero hero in allHeroes)
        {
            classesDict[hero._class].Add(hero);
            specsDict[hero._specs[0]].Add(hero);
            if (hero._specs.Count > 1)
                specsDict[hero._specs[1]].Add(hero);
        }

        // Test
        for (int i = 0; i < specsDict.Count; i++)
        {
            Debug.LogWarning(sps[i]);
            foreach (Hero hero in specsDict[sps[i]])
            {
                Debug.Log(hero._class);
            }
        }
        //
    }
}
