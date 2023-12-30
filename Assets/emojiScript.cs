using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using KModkit;
using Rnd = UnityEngine.Random;

public class emojiScript : MonoBehaviour {

    public KMBombInfo Bomb;
    public KMAudio Audio;

    public KMSelectable[] Buttons;
    public SpriteRenderer[] SpriteSlots;
    public Sprite[] EmojiSprites;
    public Sprite[] GlassSprites;
    public Sprite EmptySprite;
    public GameObject Sphere;
    public GameObject Unit;

    string[] names = { "ab", "abacus", "abc", "abcd", "accept", "accordion", "adult", "airplane", "alembic", "alien", "ambulance", "amphora", "anchor", "angel", "anger", "angry", "anguished", "ant", "apple", "aquarius", "aries", "art", "artist", "astonished", "astronaut", "atm", "avocado", "axe", "baby", "back", "bacon", "badger", "badminton", "bagel", "balloon", "bamboo", "banana", "bangbang", "banjo", "bank", "barber", "baseball", "basket", "basketball", "bat", "bath", "bathtub", "battery", "bear", "beaver", "bed", "bee", "beer", "beers", "beetle", "beginner", "bell", "bento", "bike", "bikini", "bird", "birthday", "bison", "blossom", "blowfish", "blueberries", "blush", "boar", "bomb", "bone", "book", "bookmark", "books", "boom", "boomerang", "boot", "bouquet", "bowling", "boy", "brain", "bread", "bricks", "briefcase", "briefs", "broccoli", "broom", "bucket", "bug", "bulb", "burrito", "bus", "busstop", "butter", "butterfly", "cactus", "cake", "calendar", "calling", "camel", "camera", "camping", "cancer", "candle", "candy", "capricorn", "carrot", "cat", "cd", "chains", "chair", "chart", "cherries", "chestnut", "chicken", "child", "chipmunk", "chopsticks", "cinema", "cityscape", "cl", "clap", "clapper", "clipboard", "cloud", "clubs", "coat", "cockroach", "cocktail", "coconut", "coffee", "coffin", "coin", "comet", "compass", "compression", "computer", "confounded", "confused", "congratulations", "construction", "cook", "cookie", "cooking", "cool", "corn", "couple", "couplekiss", "cow", "crab", "cricket", "crocodile", "croissant", "crown", "cry", "cucumber", "cupcake", "cupid", "curry", "customs", "cyclone", "dancer", "dango", "dart", "dash", "date", "deer", "desert", "diamonds", "disappointed", "dizzy", "dna", "dodo", "dog", "dollar", "dolls", "dolphin", "door", "doughnut", "dragon", "dress", "droplet", "duck", "dumpling", "dvd", "eagle", "ear", "egg", "eggplant", "eight", "elephant", "elevator", "elf", "end", "envelope", "euro", "exclamation", "expressionless", "eye", "eyeglasses", "eyes", "factory", "fairy", "falafel", "farmer", "fax", "fearful", "feather", "ferry", "firecracker", "firefighter", "fireworks", "fish", "fist", "five", "flags", "flamingo", "flashlight", "flatbread", "flushed", "fly", "fog", "foggy", "fondue", "foot", "football", "footprints", "fountain", "four", "free", "fries", "frog", "frowning", "fuelpump", "garlic", "gear", "gem", "gemini", "genie", "ghost", "gift", "giraffe", "girl", "gloves", "goat", "goggles", "golf", "gorilla", "grapes", "grimacing", "grin", "grinning", "guitar", "gun", "hamburger", "hammer", "hamster", "handbag", "hash", "headphones", "headstone", "heart", "heartbeat", "heartpulse", "hearts", "hedgehog", "helicopter", "herb", "hibiscus", "hippopotamus", "hockey", "hole", "hook", "horse", "hospital", "hotel", "hotsprings", "hourglass", "house", "hushed", "hut", "icecream", "id", "imp", "infinity", "innocent", "interrobang", "japan", "jeans", "jigsaw", "joy", "joystick", "judge", "kangaroo", "key", "keyboard", "kimono", "kiss", "kissing", "kite", "knife", "knot", "koala", "koko", "label", "lacrosse", "ladder", "leaves", "ledger", "leg", "lemon", "leo", "leopard", "libra", "link", "lips", "lipstick", "lizard", "llama", "lobster", "lock", "lollipop", "loop", "loudspeaker", "luggage", "lungs", "mag", "mage", "magnet", "mahjong", "mailbox", "mammoth", "man", "mango", "mask", "mate", "mechanic", "mega", "melon", "mens", "mermaid", "metro", "microbe", "microphone", "microscope", "minibus", "minidisc", "mirror", "moneybag", "monkey", "monorail", "mosquito", "motorboat", "motorcycle", "motorway", "mountain", "mouse", "moyai", "muscle", "mushroom", "mute", "necktie", "new", "newspaper", "ng", "nine", "ninja", "nose", "notebook", "notes", "ocean", "octopus", "oden", "office", "ok", "olive", "on", "one", "onion", "orangutan", "otter", "owl", "ox", "oyster", "package", "pager", "pancakes", "paperclip", "parachute", "parking", "parrot", "peach", "peacock", "pear", "penguin", "pensive", "persevere", "pick", "pie", "pig", "pill", "pilot", "pineapple", "pisces", "pizza", "placard", "plunger", "poodle", "popcorn", "postbox", "potato", "pouch", "pound", "pretzel", "prince", "princess", "printer", "punch", "purse", "pushpin", "question", "rabbit", "raccoon", "racehorse", "radio", "rage", "rainbow", "ram", "ramen", "rat", "razor", "receipt", "recycle", "relaxed", "relieved", "repeat", "restroom", "rewind", "ribbon", "rice", "ring", "rock", "rocket", "rooster", "rose", "rosette", "sa", "sagittarius", "sailboat", "sake", "salt", "sandal", "sandwich", "santa", "sari", "satellite", "sauropod", "saxophone", "scales", "scarf", "school", "scientist", "scissors", "scooter", "scorpion", "scorpius", "scream", "screwdriver", "scroll", "seal", "seat", "secret", "seedling", "selfie", "seven", "shamrock", "shark", "sheep", "shell", "shield", "ship", "shirt", "shorts", "shower", "shrimp", "singer", "six", "skateboard", "ski", "skier", "skunk", "sled", "sleeping", "sleepy", "sloth", "smile", "smiley", "smirk", "smoking", "snail", "snake", "snowboarder", "snowflake", "snowman", "soap", "sob", "soccer", "socks", "softball", "soon", "sos", "sound", "spades", "spaghetti", "sparkle", "sparkler", "sparkles", "speaker", "speedboat", "spider", "sponge", "spoon", "squid", "stadium", "star", "stars", "station", "stethoscope", "stew", "stopwatch", "strawberry", "student", "sunflower", "sunglasses", "sunny", "sunrise", "superhero", "supervillain", "sushi", "swan", "sweat", "symbols", "syringe", "taco", "tada", "tamale", "tangerine", "taurus", "taxi", "tea", "teacher", "teapot", "technologist", "telephone", "telescope", "tennis", "tent", "thermometer", "thread", "three", "ticket", "tiger", "tm", "toilet", "tomato", "tongue", "toolbox", "tooth", "toothbrush", "top", "tophat", "trackball", "tractor", "train", "tram", "trident", "triumph", "trolleybus", "trophy", "truck", "trumpet", "tulip", "turkey", "turtle", "tv", "two", "umbrella", "unamused", "underage", "unlock", "up", "vampire", "vhs", "violin", "virgo", "volcano", "volleyball", "vs", "waffle", "warning", "wastebasket", "watch", "watermelon", "wave", "wc", "weary", "wedding", "whale", "wheelchair", "window", "wink", "wolf", "woman", "womens", "wood", "worm", "worried", "wrench", "yarn", "yen", "yum", "zap", "zebra", "zero", "zombie", "zzz" };
    string[] flags = { "ac", "ad", "ae", "af", "ag", "ai", "al", "am", "ao", "aq", "ar", "as", "at", "au", "aw", "ax", "az", "ba", "bb", "bd", "be", "bf", "bg", "bh", "bi", "bj", "bl", "bm", "bn", "bo", "bq", "br", "bs", "bt", "bv", "bw", "by", "bz", "ca", "cc", "cd", "cf", "cg", "ch", "ci", "ck", "cl", "cm", "cn", "co", "cp", "cr", "cu", "cv", "cw", "cx", "cy", "cz", "de", "dg", "dj", "dk", "dm", "do", "dz", "ea", "ec", "ee", "eg", "eh", "er", "es", "et", "eu", "fi", "fj", "fk", "fm", "fo", "fr", "ga", "gb", "gd", "ge", "gf", "gg", "gh", "gi", "gl", "gm", "gn", "gp", "gq", "gr", "gs", "gt", "gu", "gw", "gy", "hk", "hm", "hn", "hr", "ht", "hu", "ic", "id", "ie", "il", "im", "in", "io", "iq", "ir", "is", "it", "je", "jm", "jo", "jp", "ke", "kg", "kh", "ki", "km", "kn", "kp", "kr", "kw", "ky", "kz", "la", "lb", "lc", "li", "lk", "lr", "ls", "lt", "lu", "lv", "ly", "ma", "mc", "md", "me", "mf", "mg", "mh", "mk", "ml", "mm", "mn", "mo", "mp", "mq", "mr", "ms", "mt", "mu", "mv", "mw", "mx", "my", "mz", "na", "nc", "ne", "nf", "ng", "ni", "nl", "no", "np", "nr", "nu", "nz", "om", "pa", "pe", "pf", "pg", "ph", "pk", "pl", "pm", "pn", "pr", "ps", "pt", "pw", "py", "qa", "re", "ro", "rs", "ru", "rw", "sa", "sb", "sc", "sd", "se", "sg", "sh", "si", "sj", "sk", "sl", "sm", "sn", "so", "sr", "ss", "st", "sv", "sx", "sy", "sz", "ta", "tc", "td", "tf", "tg", "th", "tj", "tk", "tl", "tm", "tn", "to", "tr", "tt", "tv", "tw", "tz", "ua", "ug", "um", "us", "uy", "uz", "va", "vc", "ve", "vg", "vi", "vn", "vu", "wf", "ws", "xk", "ye", "yt", "za", "zm", "zw" };
    int answer;
    int[] submitted = { 0, 0 };
    bool started = false;
    float timer = 0f;

    //Logging
    static int moduleIdCounter = 1;
    int moduleId;
    private bool moduleSolved;

    void Awake () {
        moduleId = moduleIdCounter++;

        foreach (KMSelectable Button in Buttons) {
            Button.OnInteract += delegate () { Press(Button); return false; };
        }
    }

    void Start () {
        GeneratePuzzle();
    }

    void GeneratePuzzle () {
        int left = Rnd.Range(0, names.Length);
        int right = Rnd.Range(0, names.Length);
        SpriteSlots[0].sprite = EmojiSprites[left];
        SpriteSlots[1].sprite = EmojiSprites[right];
        Debug.LogFormat("[Emoji #{0}] Puzzle: {1} {2}", moduleId, names[left], names[right]);

        int lefty = names[left].Length;
        int righty = names[right].Length;

        Debug.LogFormat("[Emoji #{0}] Grid:", moduleId);
        string logging = "";
        bool[,] grid = new bool[lefty, righty];
        for (int l = 0; l < lefty; l++) {
            for (int r = 0; r < righty; r++) {
                string s = names[left][l].ToString() + names[right][r]; //this line is ugly :(
                if (flags.Contains(s)) {
                    grid[l, r] = true;
                    logging += "#";
                } else { logging += "."; }
            }
            if (l != lefty - 1) { logging += "|"; }
        }
        Debug.LogFormat("[Emoji #{0}] {1}", moduleId, logging);

        answer = 0;
        int [,] othergrid = new int[lefty, righty];
        int area = lefty * righty;
        int visited = 0;
        bool lookingFor = false;
        string debugLogging = "";
        while (area > visited) {
            for (int q = 0; q < area; q++) {
                if (othergrid[q / righty, q % righty] == 0) {
                    debugLogging += String.Format("X({0},{1})", q / righty, q % righty);
                    othergrid[q / righty, q % righty] = 1;
                    visited++;
                    lookingFor = grid[q / righty, q % righty];
                    break;
                }
            }
            backUp:
            int added = 0;
            for (int q = 0; q < area; q++) {
                if (othergrid[q / righty, q % righty] == 1) {
                    if (q / righty - 1 != -1) { //up
                        if (othergrid[q / righty - 1, q % righty] == 0 && grid[q / righty - 1, q % righty] == lookingFor) {
                            debugLogging += String.Format("U({0},{1})", q / righty - 1, q % righty);
                            othergrid[q / righty - 1, q % righty] = 1;
                            visited++; added++;
                        }
                    }
                    if (q / righty + 1 != lefty) { //down
                        if (othergrid[q / righty + 1, q % righty] == 0 && grid[q / righty + 1, q % righty] == lookingFor) {
                            debugLogging += String.Format("D({0},{1})", q / righty + 1, q % righty);
                            othergrid[q / righty + 1, q % righty] = 1;
                            visited++; added++;
                        }
                    }
                    if (q % righty - 1 != -1) { //left
                        if (othergrid[q / righty, q % righty - 1] == 0 && grid[q / righty, q % righty - 1] == lookingFor) {
                            debugLogging += String.Format("L({0},{1})", q / righty, q % righty - 1);
                            othergrid[q / righty, q % righty - 1] = 1;
                            visited++; added++;
                        }
                    }
                    if (q % righty + 1 != righty) { //right
                        if (othergrid[q / righty, q % righty + 1] == 0 && grid[q / righty, q % righty + 1] == lookingFor) {
                            debugLogging += String.Format("R({0},{1})", q / righty, q % righty + 1);
                            othergrid[q / righty, q % righty + 1] = 1;
                            visited++; added++;
                        }
                    }
                }
            }
            if (added != 0) {
                goto backUp;
            } else {
                answer++;
                for (int q = 0; q < area; q++) {
                    if (othergrid[q / righty, q % righty] == 1) {
                        othergrid[q / righty, q % righty] = 2;
                    }
                }
            }
        }
        Debug.LogFormat("<Emoji #{0}> {1}", moduleId, debugLogging);
        Debug.LogFormat("[Emoji #{0}] This grid has {1} regions.", moduleId, answer);
        if (answer % 100 == 0) {
            Debug.LogFormat("[Emoji #{0}] Somehow the number of regions is an exact multiple of 100. Probably worth buying a lottery ticket with that kind of luck. Resetting...", moduleId);
            GeneratePuzzle();
        }
    }

    void Press(KMSelectable Button) {
        if (moduleSolved) { return; }
        Audio.PlaySoundAtTransform("punch-" + Rnd.Range(0, 13).ToString("D2"), transform);
        Button.AddInteractionPunch();
        if (Button == Buttons[0]) {
            submitted[0]++;
            SpriteSlots[2].sprite = GlassSprites[Math.Min(submitted[0], 9) - 1];
        } else {
            submitted[1]++;
            SpriteSlots[3].sprite = GlassSprites[Math.Min(submitted[1], 9) - 1];
        }
        if (!started) {
            started = true;
            StartCoroutine(Clock());
        } else {
            timer = 0f;
        }
    }

    IEnumerator Clock () {
        while (timer < 2f) {
            timer += Time.deltaTime;
            yield return null;
        }
        answer %= 100;
        Debug.LogFormat("[Emoji #{0}] Submitted {1} left punches and {2} right punches.", moduleId, submitted[0], submitted[1]);
        if (submitted[0] == answer / 10 && submitted[1] == answer % 10) {
            Debug.LogFormat("[Emoji #{0}] Monitor sufficiently destroyed, module solved.", moduleId);
            GetComponent<KMBombModule>().HandlePass();
            moduleSolved = true;
            Audio.PlaySoundAtTransform("gunshot", transform);
            Sphere.transform.localScale = new Vector3(1f, 1f, 1f);
            yield return new WaitForSeconds(0.04f);
            Sphere.transform.localScale = new Vector3(0f, 0f, 0f);
            float ang = -102f;
            for (int a = 0; a < 60; a++) {
                switch (a) {
                    case 0: Unit.transform.localPosition = new Vector3(0f, 0.0356f, 0.0053f); Unit.transform.localRotation = Quaternion.Euler(9.782001f, 0f, 0f); break;
                    case 1: Unit.transform.localPosition = new Vector3(0f, 0.0416f, 0.0089f); Unit.transform.localRotation = Quaternion.Euler(1.028f, 0f, 0f); break;
                    case 2: Unit.transform.localPosition = new Vector3(0f, 0.0553f, 0.0066f); Unit.transform.localRotation = Quaternion.Euler(-6.183f, 0f, 0f); break;
                    case 3: Unit.transform.localPosition = new Vector3(0f, 0.0765f, 0.006234767f); Unit.transform.localRotation = Quaternion.Euler(-15.062f, 0f, 0f); break;
                    case 4: Unit.transform.localPosition = new Vector3(0f, 0.0992f, 0.0049f); Unit.transform.localRotation = Quaternion.Euler(-32.985f, 0f, 0f); break;
                    case 5: case 6: Unit.transform.localPosition = new Vector3(0f, 0.1216f, -0.0092f); Unit.transform.localRotation = Quaternion.Euler(-55.049f, 0f, 0f); break;
                    case 7: case 8: Unit.transform.localPosition = new Vector3(0f, 0.137f, -0.0309f); Unit.transform.localRotation = Quaternion.Euler(-71.26501f, 0f, 0f); break;
                    case 9: case 10: Unit.transform.localPosition = new Vector3(0f, 0.1461f, -0.0546f); Unit.transform.localRotation = Quaternion.Euler(-90f, 0f, 0f); break;
                    case 11: case 12: Unit.transform.localPosition = new Vector3(0f, 0.1481001f, -0.08064608f); Unit.transform.localRotation = Quaternion.Euler(-102f, 0f, 0f); break;
                    case 59: Unit.transform.localScale = new Vector3(0f, 0f, 0f); break;
                    default: Unit.transform.localPosition -= new Vector3(0f, 0f, 0.03f); ang -= 12f; Unit.transform.localRotation = Quaternion.Euler(ang, 0f, 0f); break;
                }
                yield return new WaitForSeconds(0.016f);
            }
        } else {
            submitted = new int[] { Math.Min(submitted[0], 9), Math.Min(submitted[1], 9)};
            while (submitted[0] + submitted[1] != 0) {
                Audio.PlaySoundAtTransform("bass", transform);
                if (submitted[0] != 0) { submitted[0]--; }
                if (submitted[1] != 0) { submitted[1]--; }
                SpriteSlots[2].sprite = submitted[0] != 0 ? GlassSprites[submitted[0] - 1] : EmptySprite;
                SpriteSlots[3].sprite = submitted[1] != 0 ? GlassSprites[submitted[1] - 1] : EmptySprite;
                yield return new WaitForSeconds(0.05f);
            }
            Debug.LogFormat("[Emoji #{0}] Monitor destruction failure detected, strike! Rematerializing...", moduleId);
            GetComponent<KMBombModule>().HandleStrike();
            started = false;
            timer = 0f;
            GeneratePuzzle();
        }
    }

}
