using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Items
{
    public int ID { get; set; }
    public string Title { get; set; }
    public int Value { get; set; }
    public int DamageMin { get; set; }
    public int DamageMax { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }
    public bool Stackable { get; set; }
    public Sprite Sprite { get; set; }

    public Items(int id, string title, int value, int damageMIn, int damageMax, string description, string slug, bool stackable)
    {
        this.ID = id;
        this.Title = title;
        this.Value = value;
        this.DamageMin = damageMIn;
        this.DamageMax = DamageMax;
        this.Description = description;
        this.Slug = slug;
        this.Stackable = stackable;
        this.Sprite = Resources.Load<Sprite>("Sprites/Item/" + slug);
    }
    public Items()
    {
        this.ID = -1;
    }
}
