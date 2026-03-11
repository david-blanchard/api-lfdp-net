# la-foire-des-prix API (ASP.NET Core)

Cette application .NET 10 expose une API "façon API Platform" offrant :

- CRUD complet pour la ressource `Product`
- Filtrage combinable (`search`, `category`, `currency`, `minPrice`, `maxPrice`, `isPublished`)
- Pagination et tri (`page`, `pageSize`, `sortBy`, `sortDirection`)
- Données d'exemple auto-générées via Entity Framework Core In-Memory

## Actions menées

- **Infrastructure & données** : introduction d'Entity Framework Core InMemory, entité `Product`, `AppDbContext` et `SeedData` (50 articles de démonstration).
- **Contrats & filtres** : création des DTO (`ProductInput`, `ProductResponse`, `PagedResponse<T>`, `PaginationQuery`) et du couple `IResourceFilter<T>` / `ProductFilter` pour reproduire les filtres combinables d'API Platform.
- **API minimaliste** : module `ProductEndpoints` offrant GET (paginé/filtré/trié), GET item, POST, PUT, PATCH partiel et DELETE avec validation DataAnnotations.
- **Outils DX** : fichier `la-foire-des-prix.http` prêt à l'emploi et documentation OpenAPI exposée automatiquement en environnement de développement.

## Démarrage rapide

```bash
cd la-foire-des-prix
DOTNET_ENVIRONMENT=Development dotnet run
```

Une fois l'application lancée :

- Parcours OpenAPI : `https://localhost:5001/openapi/v1.json`
- Liste paginée : `GET https://localhost:5001/api/products?page=1&pageSize=10&sortBy=price&sortDirection=asc`
- Création : `POST https://localhost:5001/api/products`

Exemple de corps JSON :

```json
{
  "name": "Cafetière italienne",
  "description": "Une cafetière en inox 6 tasses",
  "category": "maison",
  "price": 49.9,
  "currency": "EUR",
  "isPublished": true,
  "stockQuantity": 120
}
```

## Extensions utiles

- `ProductFilter` implémente une interface `IResourceFilter<T>` afin de reproduire la configuration déclarative d'API Platform.
- `PaginationQuery` et `PagedResponse<T>` fournissent les métadonnées attendues (totaux, navigation, etc.).

Pour ajouter une nouvelle ressource, créez simplement :

1. Une entité EF Core
2. Un DTO d'entrée/sortie
3. Un filtre spécifique (`IResourceFilter<T>`) si nécessaire
4. Un module d'endpoints similaire à `ProductEndpoints`

