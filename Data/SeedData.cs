using System.Collections.Generic;
using LaFoireDesPrix.Entities;
using LaFoireDesPrix.Enums;
using Microsoft.EntityFrameworkCore;

namespace LaFoireDesPrix.Data;

public static class SeedData
{
    private record CountrySeed(string Code, string Name);
    private record CitySeed(string Name, string CountryCode, string Zipcode);
    private record BrandSeed(string Name);
    private record ProductSeed(string Name, string Description, string MoreInfo, decimal Price, string BrandName);
    private record ImageSeed(string Url, string Alt, string Title);
    private record ProductImageSeed(string ProductName, string ImageAlt);
    private record CampaignSeed(string Name, DateTime Start, DateTime End, int Discount);
    private record CampaignProductSeed(string CampaignName, string ProductName);
    private record BillLineSeed(string ProductName, int Quantity);

    private static readonly CountrySeed[] CountrySeeds =
    {
        new("US", "United States"),
        new("CA", "Canada"),
        new("GB", "United Kingdom"),
        new("AU", "Australia"),
        new("DE", "Germany"),
        new("FR", "France"),
        new("IT", "Italy"),
        new("ES", "Spain"),
        new("JP", "Japan"),
        new("CN", "China")
    };

    private static readonly CitySeed[] CitySeeds =
    {
        new("New York", "US", "10001"),
        new("Los Angeles", "US", "90001"),
        new("Chicago", "US", "60601"),
        new("Houston", "US", "77001"),
        new("Phoenix", "US", "85001"),
        new("Philadelphia", "US", "19019"),
        new("San Antonio", "US", "78201"),
        new("San Diego", "US", "92101"),
        new("Dallas", "US", "75201"),
        new("San Jose", "US", "95101"),
        new("Toronto", "CA", "M5H"),
        new("Vancouver", "CA", "V5K"),
        new("Montreal", "CA", "H1A"),
        new("Calgary", "CA", "T1Y"),
        new("Ottawa", "CA", "K1A"),
        new("Edmonton", "CA", "T5A"),
        new("Mississauga", "CA", "L4T"),
        new("Winnipeg", "CA", "R2C"),
        new("Quebec City", "CA", "G1A"),
        new("Hamilton", "CA", "L8K"),
        new("London", "GB", "EC1A"),
        new("Birmingham", "GB", "B1"),
        new("Leeds", "GB", "LS1"),
        new("Glasgow", "GB", "G1"),
        new("Sheffield", "GB", "S1"),
        new("Bradford", "GB", "BD1"),
        new("Liverpool", "GB", "L1"),
        new("Edinburgh", "GB", "EH1"),
        new("Manchester", "GB", "M1"),
        new("Bristol", "GB", "BS1"),
        new("Sydney", "AU", "2000"),
        new("Melbourne", "AU", "3000"),
        new("Brisbane", "AU", "4000"),
        new("Perth", "AU", "6000"),
        new("Adelaide", "AU", "5000"),
        new("Gold Coast", "AU", "4217"),
        new("Canberra", "AU", "2600"),
        new("Newcastle", "AU", "2300"),
        new("Wollongong", "AU", "2500"),
        new("Logan City", "AU", "4114"),
        new("Berlin", "DE", "10115"),
        new("Hamburg", "DE", "20095"),
        new("Munich", "DE", "80331"),
        new("Cologne", "DE", "50667"),
        new("Frankfurt", "DE", "60311"),
        new("Stuttgart", "DE", "70173"),
        new("Düsseldorf", "DE", "40213"),
        new("Dortmund", "DE", "44135"),
        new("Essen", "DE", "45127"),
        new("Leipzig", "DE", "04109"),
        new("Paris", "FR", "75001"),
        new("Marseille", "FR", "13001"),
        new("Lyon", "FR", "69001"),
        new("Toulouse", "FR", "31000"),
        new("Nice", "FR", "06000"),
        new("Nantes", "FR", "44000"),
        new("Strasbourg", "FR", "67000"),
        new("Montpellier", "FR", "34000"),
        new("Bordeaux", "FR", "33000"),
        new("Lille", "FR", "59000"),
        new("Rennes", "FR", "35000"),
        new("Reims", "FR", "51100"),
        new("Le Havre", "FR", "76600"),
        new("Saint-Étienne", "FR", "42000"),
        new("Toulon", "FR", "83000"),
        new("Grenoble", "FR", "38000"),
        new("Dijon", "FR", "21000"),
        new("Angers", "FR", "49000"),
        new("Nîmes", "FR", "30000"),
        new("Villeurbanne", "FR", "69100"),
        new("Clermont-Ferrand", "FR", "63000"),
        new("Le Mans", "FR", "72000"),
        new("Aix-en-Provence", "FR", "13100"),
        new("Brest", "FR", "29200"),
        new("Limoges", "FR", "87000"),
        new("Tours", "FR", "37000"),
        new("Amiens", "FR", "80000"),
        new("Perpignan", "FR", "66000"),
        new("Boulogne-Billancourt", "FR", "92100"),
        new("Metz", "FR", "57000"),
        new("Laon", "FR", "02000"),
        new("Moulins", "FR", "03000"),
        new("Digne-les-Bains", "FR", "04000"),
        new("Gap", "FR", "05000"),
        new("Privas", "FR", "07000"),
        new("Charleville-Mézières", "FR", "08000"),
        new("Foix", "FR", "09000"),
        new("Troyes", "FR", "10000"),
        new("Carcassonne", "FR", "11000"),
        new("Rodez", "FR", "12000"),
        new("Chambéry", "FR", "73000"),
        new("Annecy", "FR", "74000"),
        new("Melun", "FR", "77000"),
        new("Versailles", "FR", "78000"),
        new("Niort", "FR", "79000"),
        new("Albi", "FR", "81000"),
        new("Montauban", "FR", "82000"),
        new("Draguignan", "FR", "83300"),
        new("Avignon", "FR", "84000"),
        new("La Roche-sur-Yon", "FR", "85000"),
        new("Poitiers", "FR", "86000"),
        new("Auxerre", "FR", "89000"),
        new("Belfort", "FR", "90000"),
        new("Évry", "FR", "91000"),
        new("Nanterre", "FR", "92000"),
        new("Bobigny", "FR", "93000"),
        new("Créteil", "FR", "94000"),
        new("Pontoise", "FR", "95000"),
        new("Guéret", "FR", "23000"),
        new("Périgueux", "FR", "24000"),
        new("Besançon", "FR", "25000"),
        new("Valence", "FR", "26000"),
        new("Évreux", "FR", "27000"),
        new("Chartres", "FR", "28000"),
        new("Quimper", "FR", "29000"),
        new("Lons-le-Saunier", "FR", "39000"),
        new("Mont-de-Marsan", "FR", "40000"),
        new("Blois", "FR", "41000"),
        new("Le Puy-en-Velay", "FR", "43000"),
        new("Saint-Lô", "FR", "50000"),
        new("Orléans", "FR", "45000"),
        new("Cahors", "FR", "46000"),
        new("Agen", "FR", "47000"),
        new("Mende", "FR", "48000"),
        new("Alençon", "FR", "61000"),
        new("Arras", "FR", "62000"),
        new("Pau", "FR", "64000"),
        new("Tarbes", "FR", "65000"),
        new("Mâcon", "FR", "71000"),
        new("Vesoul", "FR", "70000"),
        new("Rouen", "FR", "76000"),
        new("Mont-Saint-Aignan", "FR", "76300"),
        new("Saint-Étienne-du-Rouvray", "FR", "76800"),
        new("Épinal", "FR", "88000"),
        new("Ajaccio", "FR", "20000"),
        new("Bastia", "FR", "20200"),
        new("Saint-Denis", "FR", "97400"),
        new("Fort-de-France", "FR", "97200"),
        new("Basse-Terre", "FR", "97100"),
        new("Cayenne", "FR", "97300"),
        new("Mamoudzou", "FR", "97600"),
        new("Tokyo", "JP", "100-0001"),
        new("Osaka", "JP", "530-0001"),
        new("Beijing", "CN", "100000"),
        new("Shanghai", "CN", "200000"),
        new("Madrid", "ES", "28001"),
        new("Barcelona", "ES", "08001"),
        new("Rome", "IT", "00100"),
        new("Milan", "IT", "20100")
    };

    private static readonly BrandSeed[] BrandSeeds =
    {
        new("Venca"),
        new("Jodie"),
        new("Le Vestiaire")
    };

    private static readonly ProductSeed[] ProductSeeds =
    {
        new(
            "Veste en jean cintrée manches longues",
            "Veste. Col chemise. Fermeture par boutons métalliques. Manches longues avec poignets et boutons. Poches plaquées à rabats sur poitrine. Poches passepoilées sur les côtés. Empiècements.",
            "Ne pas nettoyer à sec;lavage à 30°;100% coton",
            37.99m,
            "Venca"),
        new(
            "Robe courte éponge Jodie Réédition",
            "Pièce maitresse des années 80, la robe éponge fait son comeback ! On ne l’espérait plus et pourtant, chez 3 SUISSES, nous l’avons fait...",
            "Lavage 30°;Repassage faible température;Blanchiment interdit;Pas de séchage en tambour;100% Coton",
            39.99m,
            "Jodie"),
        new(
            "Tee-shirt uni à bretelles maille élastique",
            "Ce tee-shirt à fines bretelles, indispensable en toutes saisons, se porte seul ou associé à d'autres tenues.",
            "Lavage 30°;Repassage faible température;Pas de séchage en tambour;95% coton, 5% élasthanne",
            13.99m,
            "Le Vestiaire")
    };

    private static readonly ImageSeed[] ImageSeeds =
    {
        new("/build/images/articles/veste-en-jean-cintree-manches-longues-femme-bleu-1.webp", "Veste en jean cintrée manches longues femme bleue 1/4", "Veste en jean bleu cintrée manches longues pour femme, pas chère"),
        new("/build/images/articles/veste-en-jean-cintree-manches-longues-femme-bleu-2.webp", "Veste en jean cintrée manches longues femme bleue 2/4", "Veste en jean bleu cintrée manches longues pour femme, pas chère"),
        new("/build/images/articles/veste-en-jean-cintree-manches-longues-femme-bleu-3.webp", "Veste en jean cintrée manches longues femme bleue 3/4", "Veste en jean bleu cintrée manches longues pour femme, pas chère"),
        new("/build/images/articles/veste-en-jean-cintree-manches-longues-femme-bleu-4.webp", "Veste en jean cintrée manches longues femme bleue 4/4", "Veste en jean bleu cintrée manches longues pour femme, pas chère"),
        new("/build/images/articles/robe-courte-eponge-jodie-reedition-1.webp", "Robe courte éponge Jodie Réédition 1/5", "Robe éponge courte pas chère Jodie Réédition"),
        new("/build/images/articles/robe-courte-eponge-jodie-reedition-2.webp", "Robe courte éponge Jodie Réédition 2/5", "Robe éponge courte pas chère Jodie Réédition"),
        new("/build/images/articles/robe-courte-eponge-jodie-reedition-3.webp", "Robe courte éponge Jodie Réédition 3/5", "Robe éponge courte pas chère Jodie Réédition"),
        new("/build/images/articles/robe-courte-eponge-jodie-reedition-4.webp", "Robe courte éponge Jodie Réédition 4/5", "Robe éponge courte pas chère Jodie Réédition"),
        new("/build/images/articles/robe-courte-eponge-jodie-reedition-5.webp", "Robe courte éponge Jodie Réédition 5/5", "Robe éponge courte pas chère Jodie Réédition"),
        new("/build/images/articles/tee-shirt-uni-a-bretelles-maille-elastique-femme-noir-1.webp", "T-shirt uni à bretelles noir maille élastique pour femme 1/3", "T-shirt uni à bretelles noir pas cher maille élastique"),
        new("/build/images/articles/tee-shirt-uni-a-bretelles-maille-elastique-femme-noir-2.webp", "T-shirt uni à bretelles noir maille élastique pour femme 2/3", "T-shirt uni à bretelles noir pas cher maille élastique"),
        new("/build/images/articles/tee-shirt-uni-a-bretelles-maille-elastique-femme-noir-3.webp", "T-shirt uni à bretelles noir maille élastique pour femme 3/3", "T-shirt uni à bretelles noir pas cher maille élastique")
    };

    private static readonly ProductImageSeed[] ProductImageSeeds =
    {
        new(ProductSeeds[0].Name, "Veste en jean cintrée manches longues femme bleue 1/4"),
        new(ProductSeeds[0].Name, "Veste en jean cintrée manches longues femme bleue 2/4"),
        new(ProductSeeds[0].Name, "Veste en jean cintrée manches longues femme bleue 3/4"),
        new(ProductSeeds[0].Name, "Veste en jean cintrée manches longues femme bleue 4/4")
    };

    private static readonly CampaignSeed[] CampaignSeeds =
    {
        new("Les Promos Printanières", new DateTime(2021, 03, 21), new DateTime(2021, 06, 20), 15),
        new("C'est l'Été sur les Prix !", new DateTime(2021, 06, 21), new DateTime(2021, 09, 20), 25)
    };

    private static readonly CampaignProductSeed[] CampaignProductSeeds =
    {
        new(CampaignSeeds[0].Name, ProductSeeds[0].Name),
        new(CampaignSeeds[1].Name, ProductSeeds[0].Name),
        new(CampaignSeeds[1].Name, ProductSeeds[1].Name)
    };

    private static readonly BillLineSeed[] BillLines =
    {
        new(ProductSeeds[0].Name, 1),
        new(ProductSeeds[1].Name, 2),
        new(ProductSeeds[2].Name, 1)
    };

    private static readonly (string Email, string FirstName, string LastName, UserGender Gender, string Password, bool IsAdmin)[] UserSeeds =
    {
        ("admin@lfdp.fr", "David", "Blanchard", UserGender.Male, "demo", true),
        ("david.b@lfdp.fr", "David", "Blanchard", UserGender.Male, "demo", false),
        ("dblanchard1@lfdp.fr", "David", "Blanchard", UserGender.Male, "demo", false),
        ("laura.martin@lfdp.fr", "Laura", "Martin", UserGender.Female, "password", false),
        ("emma.bernard@lfdp.fr", "Emma", "Bernard", UserGender.Female, "password", false),
        ("lucas.durand@lfdp.fr", "Lucas", "Durand", UserGender.Male, "password", false),
        ("nathan.lefebvre@lfdp.fr", "Nathan", "Lefebvre", UserGender.Male, "password", false),
        ("leo.moreau@lfdp.fr", "Léo", "Moreau", UserGender.Male, "password", false),
        ("chloe.fabre@lfdp.fr", "Chloé", "Fabre", UserGender.Female, "password", false),
        ("julie.lambert@lfdp.fr", "Julie", "Lambert", UserGender.Female, "password", false),
        ("paul.fontaine@lfdp.fr", "Paul", "Fontaine", UserGender.Male, "password", false),
        ("ines.guillaume@lfdp.fr", "Inès", "Guillaume", UserGender.Female, "password", false),
        ("marie.perrin@lfdp.fr", "Marie", "Perrin", UserGender.Female, "password", false),
        ("victor.renard@lfdp.fr", "Victor", "Renard", UserGender.Male, "password", false),
        ("sara.charles@lfdp.fr", "Sara", "Charles", UserGender.Female, "password", false),
        ("adam.caron@lfdp.fr", "Adam", "Caron", UserGender.Male, "password", false),
        ("manon.collet@lfdp.fr", "Manon", "Collet", UserGender.Female, "password", false),
        ("antoine.dupont@lfdp.fr", "Antoine", "Dupont", UserGender.Male, "password", false),
        ("maelle.gerard@lfdp.fr", "Maëlle", "Gerard", UserGender.Female, "password", false),
        ("simon.hubert@lfdp.fr", "Simon", "Hubert", UserGender.Male, "password", false)
    };

    public static async Task InitializeAsync(AppDbContext context, CancellationToken cancellationToken = default)
    {
        await context.Database.EnsureCreatedAsync(cancellationToken);

        if (await context.Products.AnyAsync(cancellationToken))
        {
            return;
        }

        var countries = await SeedCountriesAsync(context, cancellationToken);
        var cities = await SeedCitiesAsync(context, countries, cancellationToken);
        var brands = await SeedBrandsAsync(context, cancellationToken);
        var products = await SeedProductsAsync(context, brands, cancellationToken);
        var images = await SeedImagesAsync(context, cancellationToken);
        await SeedProductImagesAsync(context, products, images, cancellationToken);
        var campaigns = await SeedCampaignsAsync(context, cancellationToken);
        await SeedCampaignProductsAsync(context, campaigns, products, cancellationToken);
        var addresses = await SeedAddressesAsync(context, cities, cancellationToken);
        var users = await SeedUsersAsync(context, addresses, cancellationToken);
        await SeedBillsAsync(context, users, products, cancellationToken);
    }

    private static async Task<Dictionary<string, Country>> SeedCountriesAsync(AppDbContext context, CancellationToken ct)
    {
        var existing = await context.Countries.ToDictionaryAsync(c => c.Code, StringComparer.OrdinalIgnoreCase, ct);

        foreach (var seed in CountrySeeds)
        {
            if (existing.ContainsKey(seed.Code))
            {
                continue;
            }

            var entity = new Country
            {
                Code = seed.Code,
                Name = seed.Name
            };
            context.Countries.Add(entity);
            existing[seed.Code] = entity;
        }

        if (context.ChangeTracker.HasChanges())
        {
            await context.SaveChangesAsync(ct);
        }

        return existing;
    }

    private static async Task<Dictionary<string, City>> SeedCitiesAsync(AppDbContext context, IReadOnlyDictionary<string, Country> countries, CancellationToken ct)
    {
        var existing = await context.Cities
            .Include(c => c.Country)
            .ToDictionaryAsync(c => (c.Name, c.Zipcode), ct);

        foreach (var seed in CitySeeds)
        {
            var key = (seed.Name, seed.Zipcode);
            if (existing.ContainsKey(key))
            {
                continue;
            }

            if (!countries.TryGetValue(seed.CountryCode, out var country))
            {
                continue;
            }

            var city = new City
            {
                Name = seed.Name,
                Zipcode = seed.Zipcode,
                Country = country
            };

            context.Cities.Add(city);
            existing[key] = city;
        }

        if (context.ChangeTracker.HasChanges())
        {
            await context.SaveChangesAsync(ct);
        }

        return existing.ToDictionary(kvp => kvp.Key.Name + "|" + kvp.Key.Zipcode, kvp => kvp.Value);
    }

    private static async Task<Dictionary<string, Brand>> SeedBrandsAsync(AppDbContext context, CancellationToken ct)
    {
        var existing = await context.Brands
            .Where(b => b.Name != null)
            .ToDictionaryAsync(b => b.Name!, StringComparer.OrdinalIgnoreCase, ct);

        foreach (var seed in BrandSeeds)
        {
            if (existing.ContainsKey(seed.Name))
            {
                continue;
            }

            var brand = new Brand
            {
                Name = seed.Name,
                Slug = Slugify(seed.Name)
            };

            context.Brands.Add(brand);
            existing[seed.Name] = brand;
        }

        if (context.ChangeTracker.HasChanges())
        {
            await context.SaveChangesAsync(ct);
        }

        return existing;
    }

    private static async Task<Dictionary<string, Product>> SeedProductsAsync(
        AppDbContext context,
        IReadOnlyDictionary<string, Brand> brands,
        CancellationToken ct)
    {
        var existing = await context.Products.Include(p => p.Brand)
            .ToDictionaryAsync(p => p.Name, StringComparer.OrdinalIgnoreCase, ct);

        foreach (var seed in ProductSeeds)
        {
            if (existing.ContainsKey(seed.Name))
            {
                continue;
            }

            if (!brands.TryGetValue(seed.BrandName, out var brand))
            {
                continue;
            }

            var product = new Product
            {
                Name = seed.Name,
                Slug = Slugify(seed.Name),
                Description = seed.Description,
                MoreInfo = seed.MoreInfo,
                Price = seed.Price,
                Currency = "EUR",
                Category = "mode",
                StockQuantity = 100,
                IsPublished = true,
                Brand = brand
            };

            context.Products.Add(product);
            existing[seed.Name] = product;
        }

        if (context.ChangeTracker.HasChanges())
        {
            await context.SaveChangesAsync(ct);
        }

        return existing;
    }

    private static async Task<Dictionary<string, Image>> SeedImagesAsync(AppDbContext context, CancellationToken ct)
    {
        var existing = await context.Images.ToDictionaryAsync(i => i.Alt, StringComparer.OrdinalIgnoreCase, ct);

        foreach (var seed in ImageSeeds)
        {
            if (existing.ContainsKey(seed.Alt))
            {
                continue;
            }

            var image = new Image
            {
                Url = seed.Url,
                Alt = seed.Alt,
                Title = seed.Title
            };

            context.Images.Add(image);
            existing[seed.Alt] = image;
        }

        if (context.ChangeTracker.HasChanges())
        {
            await context.SaveChangesAsync(ct);
        }

        return existing;
    }

    private static async Task SeedProductImagesAsync(
        AppDbContext context,
        IReadOnlyDictionary<string, Product> products,
        IReadOnlyDictionary<string, Image> images,
        CancellationToken ct)
    {
        var existing = await context.ProductImages
            .Include(pi => pi.Product)
            .Include(pi => pi.Image)
            .ToListAsync(ct);

        bool changed = false;
        foreach (var seed in ProductImageSeeds)
        {
            if (!products.TryGetValue(seed.ProductName, out var product) ||
                !images.TryGetValue(seed.ImageAlt, out var image))
            {
                continue;
            }

            var alreadyLinked = existing.Any(pi =>
                pi.Product?.Id == product.Id && string.Equals(pi.Image?.Alt, seed.ImageAlt, StringComparison.OrdinalIgnoreCase));

            if (alreadyLinked)
            {
                continue;
            }

            var productImage = new ProductImage
            {
                Product = product,
                Image = image
            };

            context.ProductImages.Add(productImage);
            changed = true;
        }

        if (changed)
        {
            await context.SaveChangesAsync(ct);
        }
    }

    private static async Task<Dictionary<string, Campaign>> SeedCampaignsAsync(AppDbContext context, CancellationToken ct)
    {
        var existing = await context.Campaigns
            .Where(c => c.Name != null)
            .ToDictionaryAsync(c => c.Name!, StringComparer.OrdinalIgnoreCase, ct);

        foreach (var seed in CampaignSeeds)
        {
            if (existing.ContainsKey(seed.Name))
            {
                continue;
            }

            var campaign = new Campaign
            {
                Name = seed.Name,
                Slug = Slugify(seed.Name),
                StartsAt = seed.Start,
                EndsAt = seed.End,
                Discount = seed.Discount
            };

            context.Campaigns.Add(campaign);
            existing[seed.Name] = campaign;
        }

        if (context.ChangeTracker.HasChanges())
        {
            await context.SaveChangesAsync(ct);
        }

        return existing;
    }

    private static async Task SeedCampaignProductsAsync(
        AppDbContext context,
        IReadOnlyDictionary<string, Campaign> campaigns,
        IReadOnlyDictionary<string, Product> products,
        CancellationToken ct)
    {
        var existing = await context.CampaignProducts
            .Include(cp => cp.Campaign)
            .Include(cp => cp.Product)
            .ToListAsync(ct);

        bool changed = false;
        foreach (var seed in CampaignProductSeeds)
        {
            if (!campaigns.TryGetValue(seed.CampaignName, out var campaign) ||
                !products.TryGetValue(seed.ProductName, out var product))
            {
                continue;
            }

            var alreadyLinked = existing.Any(cp =>
                cp.Campaign?.Id == campaign.Id && cp.Product?.Id == product.Id);

            if (alreadyLinked)
            {
                continue;
            }

            var entity = new CampaignProduct
            {
                Campaign = campaign,
                Product = product
            };

            context.CampaignProducts.Add(entity);
            changed = true;
        }

        if (changed)
        {
            await context.SaveChangesAsync(ct);
        }
    }

    private static async Task<List<Address>> SeedAddressesAsync(
        AppDbContext context,
        IReadOnlyDictionary<string, City> cities,
        CancellationToken ct)
    {
        var addresses = await context.Addresses.Include(a => a.City).ToListAsync(ct);

        if (addresses.Count > 0)
        {
            return addresses;
        }

        var streetNames = new[]
        {
            "Rue des Lilas",
            "Avenue Victor Hugo",
            "Boulevard Voltaire",
            "Rue de la République",
            "Place des Fleurs",
            "Allée des Peupliers",
            "Impasse des Artisans",
            "Chemin des Vignes",
            "Rue des Écoles",
            "Rue du Général"
        };

        var line2Options = new[]
        {
            "Appartement 12",
            "Bâtiment A, Apt 5",
            "3ème étage",
            "Résidence Les Oliviers",
            "Chez Martin"
        };

        var detailOptions = new[]
        {
            "Code d'accès: 4829",
            "Interphone: Dubois",
            "Porte bleue",
            "Au fond de la cour",
            "Derrière la pharmacie"
        };

        var random = new Random(42);
        var newAddresses = new List<Address>();
        foreach (var city in cities.Values)
        {
            for (var i = 0; i < 3; i++)
            {
                var address = new Address
                {
                    Line1 = $"{random.Next(1, 200)} {streetNames[random.Next(streetNames.Length)]}",
                    City = city
                };

                if (random.NextDouble() < 0.3)
                {
                    address.Line2 = line2Options[random.Next(line2Options.Length)];
                }

                if (random.NextDouble() < 0.2)
                {
                    address.Details = detailOptions[random.Next(detailOptions.Length)];
                }

                context.Addresses.Add(address);
                newAddresses.Add(address);
            }
        }

        await context.SaveChangesAsync(ct);
        addresses.AddRange(newAddresses);
        return addresses;
    }

    private static async Task<Dictionary<string, User>> SeedUsersAsync(
        AppDbContext context,
        IReadOnlyList<Address> addresses,
        CancellationToken ct)
    {
        var existing = await context.Users
            .Include(u => u.Addresses)
            .ToDictionaryAsync(u => u.Email, StringComparer.OrdinalIgnoreCase, ct);

        var addressIndex = 0;

        foreach (var seed in UserSeeds)
        {
            if (existing.TryGetValue(seed.Email, out var user))
            {
                continue;
            }

            user = new User
            {
                Email = seed.Email,
                FirstName = seed.FirstName,
                LastName = seed.LastName,
                Gender = seed.Gender,
                Password = seed.Password,
                IsVerified = true
            };

            if (seed.IsAdmin)
            {
                user.SetRoles(new[] { User.AdminRole, User.UserRole });
            }
            else
            {
                user.SetRoles(Array.Empty<string>());
            }

            if (addresses.Count > 0)
            {
                var address = addresses[addressIndex % addresses.Count];
                user.AddAddress(address);
                addressIndex++;
            }

            context.Users.Add(user);
            existing[seed.Email] = user;
        }

        await context.SaveChangesAsync(ct);
        return existing;
    }

    private static async Task SeedBillsAsync(
        AppDbContext context,
        IReadOnlyDictionary<string, User> users,
        IReadOnlyDictionary<string, Product> products,
        CancellationToken ct)
    {
        if (await context.Bills.AnyAsync(ct))
        {
            return;
        }

        if (!users.TryGetValue("dblanchard1@lfdp.fr", out var client))
        {
            return;
        }

        var bill = new Bill
        {
            Client = client,
            Vat = 19.6m
        };

        foreach (var line in BillLines)
        {
            if (!products.TryGetValue(line.ProductName, out var product))
            {
                continue;
            }

            var billLine = new BillLineProduct
            {
                Product = product,
                Name = product.Name,
                Quantity = line.Quantity,
                Bill = bill
            };

            bill.AddBillLine(billLine);
        }

        if (!bill.BillLines.Any())
        {
            return;
        }

        context.Bills.Add(bill);
        await context.SaveChangesAsync(ct);
    }

    private static string Slugify(string value)
        => value
            .Trim()
            .ToLowerInvariant()
            .Replace("'", string.Empty)
            .Replace(" ", "-");
}