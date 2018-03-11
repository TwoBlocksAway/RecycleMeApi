using RecycleMeAPI.Data;
using RecycleMeAPI.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecycleMeAPI.Models
{
    public class DummyData
    {
        public static void Initialize(ApplicationDbContext db)
        {
            if (!db.Items.Any())
            {
                db.Items.Add(new RecyclingItem
                {
                    Name = "can",
                    ContainerType = ContainerType.Aluminum,
                    MaxSize = 1000,
                    RecyclingFee = 5,
                    Instruction = "Leave tabs on",
                    Alcoholic = false
                });
                db.Items.Add(new RecyclingItem
                {
                    Name = "bottle",
                    ContainerType = ContainerType.Plastic,
                    MaxSize = 1000,
                    RecyclingFee = 5,
                    Instruction = "Caps off, labels on",
                    Alcoholic = false
                });
                db.Items.Add(new RecyclingItem
                {
                    Name = "bottle over 1L",
                    ContainerType = ContainerType.Plastic,
                    MaxSize = 0,
                    RecyclingFee = 20,
                    Instruction = "Caps off, labels on",
                    Alcoholic = false
                });
                db.Items.Add(new RecyclingItem
                {
                    Name = "polystyrene cup",
                    ContainerType = ContainerType.PolystyreneCup,
                    MaxSize = 454,
                    RecyclingFee = 5,
                    Instruction = "Leave labels on",
                    Alcoholic = false
                });
                db.Items.Add(new RecyclingItem
                {
                    Name = "glass",
                    ContainerType = ContainerType.Glass,
                    MaxSize = 1000,
                    RecyclingFee = 5,
                    Instruction = "Caps off, labels on",
                    Alcoholic = false
                });
                db.Items.Add(new RecyclingItem
                {
                    Name = "glass over 1L",
                    ContainerType = ContainerType.Glass,
                    MaxSize = 0,
                    RecyclingFee = 20,
                    Instruction = "Caps off, labels on",
                    Alcoholic = false
                });
                db.Items.Add(new RecyclingItem
                {
                    Name = "bi-metal",
                    ContainerType = ContainerType.BiMetal,
                    MaxSize = 1000,
                    RecyclingFee = 5,
                    Instruction = "Leave labels on",
                    Alcoholic = false
                });
                db.Items.Add(new RecyclingItem
                {
                    Name = "bi-metal over 1L",
                    ContainerType = ContainerType.BiMetal,
                    MaxSize = 0,
                    RecyclingFee = 20,
                    Instruction = "Leave labels on",
                    Alcoholic = false
                });
                db.Items.Add(new RecyclingItem
                {
                     Name = "drink box",
                     ContainerType = ContainerType.DrinkBox,
                     MaxSize = 1000,
                     RecyclingFee = 5,
                     Instruction = "Cap off, straws out",
                     Alcoholic = false
                });
                db.Items.Add(new RecyclingItem
                {
                    Name = "gable top",
                    ContainerType = ContainerType.GableTop,
                    MaxSize = 1000,
                    RecyclingFee = 5,
                    Instruction = "Caps off",
                    Alcoholic = false
                });
                db.Items.Add(new RecyclingItem
                {
                    Name = "gable top over 1L",
                    ContainerType = ContainerType.GableTop,
                    MaxSize = 0,
                    RecyclingFee = 20,
                    Instruction = "Caps off",
                    Alcoholic = false
                });
                db.Items.Add(new RecyclingItem
                {
                    Name = "drink pouch",
                    ContainerType = ContainerType.DrinkPouch,
                    MaxSize = 1000,
                    RecyclingFee = 5,
                    Instruction = "Leave bag in box",
                    Alcoholic = false
                });
                db.Items.Add(new RecyclingItem
                {
                    Name = "bag-in-a-box",
                    ContainerType = ContainerType.BagInABox,
                    MaxSize = 0,
                    RecyclingFee = 20,
                    Instruction = "Leave bag in box",
                    Alcoholic = false
                });
            }

            db.SaveChanges();
        }
    }
}
