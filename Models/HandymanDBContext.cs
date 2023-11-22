using Microsoft.EntityFrameworkCore;

namespace Handyman.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }
        public DbSet<Tasks> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasks>().HasData(
                new Models.Tasks()
                {
                    Id = 1,
                    TaskName = "Seasonal Tire Swap",
                    Tools = "4-way Lug Wrench, Breaker Bar, Manual Car Jack, Lug Nut Socket(key),Torque Wrench,Tire Inflator, Tire Gauge",
                    Steps = "1. Choose a tire to start with., 2. Use lug wrench or breaker bar to turn the lug nuts counterclockwise.," +
                    "3. Loosen all of the lug nuts, but do not remove them.,4. Place the jack under the vehicle frame next to the tire you are working with (if you're unsure of the jack leverage points check your manual).," +
                    "5. Raise the vehicle with the jack until the tire has a 6-inch clearance from the ground.,6. Remove all of the lug nuts at this point and set to the side for now.," +
                    "7. Mark your tire with where you removed it from (i.e. front driver tire, rear passenger, etc.).," +
                    "8. You want to rotate your tires every year in a criss-cross pattern.  However if you have directional tires which is common for winter tires and indicated on the tire itself by an arrow and you should only rotate your tires front to back.," +
                    "9. Take the appropriate tire (i.e. if marked right rear than install on front right, etc).,10. Once you align the bolt holes to the bolts, get your lug nuts, and put them back on, but do not tighten down yet.,11. Now you can lower the jack all the way.,12. Now the lug nuts are lightly on the bolts, tighten them in a star pattern.," +
                    "13. You will want to continue this star pattern ideally with a torque wrench (star pattern twice), however the breaker bar or lug wrench will work as well., 14. Please not if you use a torque wrench you will need to look up your vehicles specs for lbs., in addition when using the torque wrench remember to do this slowly., " +
                    "15. You want to repeat steps 1-14 for the remaining 3 tires., 16. Use the tire gauge to check your tire psi (again check your owners manual if you are not sure what psi should be at)., 17. Use an air compressor of some sort to inflate any tires that are low., " +
                    "18. Please note: if you did not have a torque wrench to tighten your lug nuts, check the lug nuts in a few days with your lug wrench or breaker bar to make sure they are tight.",
                    Category = Categories.Auto,
                    SkillLevel = SkillLevel.Expert,
                    Duration = 60,
                    VideoLink = "https://www.youtube.com/embed/iJAI-cy2fZc?si=021oyj5yjFPXaNJk&amp;start=78",
                    EstimatedPrice = 200
                },
                new Models.Tasks()
                {
                    Id = 2,
                    TaskName = "Wire a Light Switch",
                    Tools = " Standard Single-Pole light switch, Electrical pliers, Screwdriver, current detector ",
                    Steps = " 1. Turn off the power at your breaker box before starting, 2. Remove the switch cover and use a current detector to make sure there's no power going to any of the wires in the electrical box, 3. Remove the old switch using a screwdriver (may need a flat head screwdriver depending on the type of screws used), 4. There are 3 wires that will be attached to the switch, a hot (black) wire, a neutral (white) wire and a ground (cooper) wire, 5. You will was to detach the wires by loosening the screws holding them onto the switch (keep the wires away from each other - safety first), 6. Wire the new switch by first making sure that each of the wires have a half inch of wire exposed and bent into a U shape to fit around the screws on the switch, 7. Using your electricians pliers there is a small hole that can be used to aid in making the U shape on the wires, 8. Wrap the black wire clockwise around one of the brass screws and tighten it down using your screwdriver, repeat this process with the white wire, 9. Wrap your copper ground wire clockwise around the green grounding screw and tighten it down using your screwdriver, 10. All that's left is to screw the switch back into the wall and place the cover over it. ",
                    Category = Categories.Home,
                    SkillLevel = SkillLevel.Intermediate,
                    Duration = 30,
                    VideoLink = "https://www.youtube.com/embed/FM8_yHlyqR4?si=1rSWVOKd1IB0Y6QJ&amp;start=78",
                    EstimatedPrice = 55
                },
                new Models.Tasks()
                {
                    Id = 3,
                    TaskName = "Unclog a toilet",
                    Tools = " Toilet Plunger, Disposable Gloves ",
                    Steps = " 1. Angle the plunger so that the flange (bottom suction part of plunger) goes into the hole at the bottom of the toilet bowl, 2. When you push in at the correct angle, it should form a seal around the hole, 3. Pump the plunger several times so it can force water into the pipe at high pressure to remove the clog, 4. Flush, 5. If for some reason that did not work and the toilet seems to be close to overflowing, open up the tank and pull open the flapper to cease the flow of water into the toilet bowl.  Once the tank stops filling, try steps 1-4 again. 6. If the problem persists it may be time to call a plumber., 7. If the toilet bowl is overflowing locate the shut-off valve behind the toilet, turn it clockwise (do not force it).  ",
                    Category = Categories.Home,
                    SkillLevel = SkillLevel.Beginner,
                    Duration = 5,
                    VideoLink = "https://www.youtube.com/embed/gIMyxQ8AB6o?si=85O3N0zpEN0p0jRF&amp;start=20",
                    EstimatedPrice = 14
                },
                new Models.Tasks()
                {
                    Id = 4,
                    TaskName = "Lawn repair - bare spots",
                    Tools = " Grass Seed, Topsoil or compost, Fertilizer, Small Gardening Trowel, Landscaping Rake ",
                    Steps = " 1. Break up the bare spot and reseed., 2. Use a small gardening shovel or rake to break up the dry spot on your lawn, 3. Remove any debris (ex. rocks dug up when breaking up the soil), 4. Spread about a half inch of compost or topsoil on the seeds, 5. Water the area immediately and generously then over the next 7-10 days water lightly about 3 times a day., 6. When you see new grass sprouting, reduce watering to once daily, 7. Feed your entire lawn with fertilizer, 8. Now you are all done! ",
                    Category = Categories.Lawn,
                    SkillLevel = SkillLevel.Intermediate,
                    Duration = 10080,
                    VideoLink = "https://www.youtube.com/embed/6iIOn2v0J8Q?si=uLftvw2aanvDOrPz",
                    EstimatedPrice = 155
                },
                new Models.Tasks()
                {
                    Id = 5,
                    TaskName = "Remove and Recaulk a Tub",
                    Tools = " Utility Blade, Flat head screw driver, Scraper, Tube silicone bath tub and tile Caulk, Latex Gloves, Caulking Gun ",
                    Steps = " 1. Put on your latex gloves, 2. Use utility blade to loosen the top and bottom of the old sealant, 3. Use the flathead screwdriver to scrape out the old sealant (be careful not to scratch the tub or tile, 4. Use the scraper to remove the remaining material, 5. Make sure the surface is clean and dry, 6. Trim the end of the caulk tube at an angle and leave a small hole (less is more), 7. Put down a tiny bead of caulk down first, 8. Dip your finger in a cup of water and gently rub your finger over that bead along the area you removed the old sealant, 9. Repeat step 8 until all old sealant has been replaced with a nice smooth surface of new caulking. ",
                    Category = Categories.Home,
                    SkillLevel = SkillLevel.Beginner,
                    Duration = 120,
                    VideoLink = "https://www.youtube.com/embed/dwGiRmeT2Ok?si=azBZRY2PeFj93Ql9",
                    EstimatedPrice = 45
                },
                new Models.Tasks()
                {
                    Id = 6,
                    TaskName = "Winterize Lawn Equipment",
                    Tools = "Fuel Stabilizer (STA-BIL Storage) Gas powered equipment only",
                    Steps = " 1. Measure 1 oz of fuel stabilizer for every 2.5 gallons of gas, 2. Add to full tank of gas, 3. Run the engine for a few minutes to make sure it is ran through the system. ",
                    Category = Categories.Lawn,
                    SkillLevel = SkillLevel.Beginner,
                    Duration = 120,
                    VideoLink = "https://www.youtube.com/embed/LBQHSTHgj5I?si=UossonVogsgWEyxk&amp;start=14",
                    EstimatedPrice = 20
                },
                new Models.Tasks()
                {
                    Id = 7,
                    TaskName = "Change Cabin Air Filter",
                    Tools = " Cabin Air Filter (for your vehicle - check owner's manual), Screwdriver ",
                    Steps = " 1. Open and remove the glove box to access the cabin air filter (check your owner's manual if you are unsure) you will need a screwdriver for this, 2. Remove the old cabin air filter, 3. Install the new filter, 4. Install the glove box using the same items you did to remove it. ",
                    Category = Categories.Auto,
                    SkillLevel = SkillLevel.Beginner,
                    Duration = 10,
                    VideoLink = "hhttps://www.youtube.com/embed/0eyzjVQFd-c?si=Jvzwwl3DA32heoHF&amp;start=71",
                    EstimatedPrice = 60
                },
                new Models.Tasks()
                {
                    Id = 8,
                    TaskName = "Jump start a vehicle",
                    Tools = " Running vehicle, Jumper cables ",
                    Steps = " 1. Make sure both vehicles are turned off, 2. Pop the hoods, and locate the batteries, 3. Make sure the jumper cables are unwound and untangled, 4. Hook the red (+) clamp to the positive terminal of the dead battery, 5. Attach the red (+) clamp to the positive terminal of the working battery, 6. Clamp the black (-) to the negative terminal of the working battery, 6. Attach the remaining black (-) to an unpainted metal surface of the dead car, 7. Start the working car, then start the dead car, 8. Remove the cables in the reverse order you attached them, 9. Let the revived car engine run for several minutes at least or drive for minimum of 15 minutes if possible. ",
                    Category = Categories.Auto,
                    SkillLevel = SkillLevel.Beginner,
                    Duration = 10,
                    VideoLink = "https://www.youtube.com/embed/VdnkRQF5Cps?si=wg6TfhN-oHD8kz22",
                    EstimatedPrice = 30
                },
                new Models.Tasks()
                {
                    Id = 9,
                    TaskName = "Remove Moles (no chemicals)",
                    Tools = " Work Gloves, Rake, Plunger Mole Trap ",
                    Steps = " 1. Rake your mole hills down so the next day you can set a trap in the active hill, 2. On day 2 safely gather trap + materials and dig a small hole to find two tunnels, 3. Put loose dirt over the top of your trap, 4. Check each morning for moles. - If caught remove from trap and put it in the tunnel so the smell deteres future moles. ",
                    Category = Categories.Lawn,
                    SkillLevel = SkillLevel.Intermediate,
                    Duration = 1440,
                    VideoLink = "https://www.youtube.com/embed/n7EGSm813zQ?si=GuQzrx4STFlYdDMz&amp;start=78",
                    EstimatedPrice = 65
                },
                new Models.Tasks()
                {
                    Id = 10,
                    TaskName = "Create a Garden",
                    Tools = " Garden Gloves, Plants, Topsoil, Mulch, Water ",
                    Steps = " 1. Consider what you want to plant, 2. Pick the best garden spot (Vegetables and flowering plants need 6-8 hrs of full sun every day, while trees, etc do not), 3. Clear the ground - remove weeds and any sod in the area you want to plant your items., 4. Have your soil tested to see what plants and/or vegetables will do best with the soil you have - a raised bed is always an option and you can just use new topsoil), 5. Loosen the soil in the new bed before planting will help roots to grow more easily and access the water and nutrients they need., 6. Be sure to work the soil only when it is moist enough to form a loose ball in your fist but dry enough to fall apart when you drop it., 7. Pick your plants (annuals, perennials, or vegetables - again depending on your soil this will help you make your decision), 8. Now you can start planting, ask your local nursey where you purchase your plants when the best time is to plant what you want to purchase., 9. Don't forget to water your plants at the right time, 10. Protect your garden with Mulch (this will keep the weeds at bay and keep moisture in.) ",
                    Category = Categories.Lawn,
                    SkillLevel = SkillLevel.Intermediate,
                    Duration = 1440,
                    VideoLink = "https://www.youtube.com/embed/5VB4TsECXWI?si=69XMjRMl4WDETUnw",
                    EstimatedPrice = 130
                },
                new Models.Tasks()
                {
                    Id = 11,
                    TaskName = "Fix a leaky faucet",
                    Tools = "Pipe Wrench, Allen Wrench",
                    Steps = " 1.Turn off the water to the sink off by shutting off flow through the valve below the sink, 2. Remove the handle from the sink, 3. Install new cartridge or stem in handle, 4.Reattach the faucet handle. ",
                    Category = Categories.Home,
                    SkillLevel = SkillLevel.Intermediate,
                    Duration = 30,
                    VideoLink = "https://www.youtube.com/embed/SYPFon69vKs?si=8_fskwk-e5OOEFAT",
                    EstimatedPrice = 35
                },
                new Models.Tasks()
                {
                    Id = 12,
                    TaskName = "Change a furnace filter",
                    Tools = "Screwdriver",
                    Steps = " 1. Locate the filter for the furnace, 2. Remove the dirty filter, 3. Insert the new filter and close the furnace. ",
                    Category = Categories.Home,
                    SkillLevel = SkillLevel.Beginner,
                    Duration = 20,
                    VideoLink = "https://www.youtube.com/embed/YaGJiF_t1Fs?si=tVehPEwufUmKIQxQ",
                    EstimatedPrice = 10
                },
                new Models.Tasks()
                {
                    Id = 13,
                    TaskName = "Change the car oil",
                    Tools = " Socket wrench,  Oil pan, Oil Filter, Oil ",
                    Steps = " 1. Jack It Up, Open It Up. First, you'll want to lift the car high enough to give yourself room to work under it, 2. Unplug It, Drain It, 3. Off With the Old Filter, 4. Drain Plug in, Filter On, 5. Fill It Back Up with Oil, 6. Check the Oil Level, Check for Leaks. ",
                    Category = Categories.Auto,
                    SkillLevel = SkillLevel.Intermediate,
                    Duration = 30,
                    VideoLink = "https://www.youtube.com/embed/O1hF25Cowv8?si=sHzce7hu7G23FCuP",
                    EstimatedPrice = 115
                },
                new Models.Tasks()
                {
                    Id = 14,
                    TaskName = "Change a car headlight bulb",
                    Tools = " Screwdriver,  Socket wrench, Headlight bulb ",
                    Steps = " 1. Turn off your car. The last thing you want is to touch a live wire, so shut off your engine and take your keys out of the ignition, 2. Pop your hood. Open your hood to look for the headlight housing, 3. Disconnect the headlight wires, 4. Remove the old headlight, 5. Install the new bulb. ",
                    Category = Categories.Auto,
                    SkillLevel = SkillLevel.Intermediate,
                    Duration = 30,
                    VideoLink = "https://www.youtube.com/embed/GcsNu_9_Di8?si=et-f-398x7Pq7iZD",
                    EstimatedPrice = 70
                },
                new Models.Tasks()
                {
                    Id = 15,
                    TaskName = "Clean a cast iron skillet",
                    Tools = " Dish brush, Vegetable Oil ",
                    Steps = " 1. Clean with hot water immediately after use. Cleaning cast iron is a thousand times easier to do if you do it ASAP, 2. Scrub excess food using a soft dish brush, 3. Dry thoroughly with a clean towel, 4. Season the pan: Apply a fresh coat of oil. ",
                    Category = Categories.Home,
                    SkillLevel = SkillLevel.Beginner,
                    Duration = 10,
                    VideoLink = "https://www.youtube.com/embed/jrWRJv_VQdo?si=h2QibtXaoKL-8H9Y",
                    EstimatedPrice = 20
                }
                );
        }
    }
}