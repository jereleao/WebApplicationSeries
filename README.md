
# WebApplicationSeries

Projeto do desafio proposto pela DIO em parceria com a Localiza.

Criando um APP simples de cadastro de séries em .NET

## Stack utilizada

**API:** C#

**Interface:** GraphQL, Playground.UI

**Persistência de Dados:** InMemory


## Uso/Exemplos

Use a seguinte mutation para criar uma nova serie

```graphql
  mutation {
    addSerie (serie: {
      title: "Breaking Bad",
      description: "Walter White history",
      categoryId: 1,
      releaseDate: "2022-12-10"
    }) {
      id,
      title,
      description,
      categoryId,
      releaseDate,
      createdAt,
      updatedAt
    }
  }
}
```

Use a seguinte mutation para atualizar uma nova serie

```graphql
  mutation {
    updateSerie(id:1,serie:{
      title: "Breaking Badly"
    }) {
      id,
      title,
      description,
      categoryId,
      releaseDate,
      createdAt,
      updatedAt
    }
  }
```

Use a seguinte mutation para atualizar uma nova categoria

```graphql
  mutation {
    addCategory (category: {
      name: "Action",
      description: "Action series"
    }) {
      id,
      name,
      description,
      createdAt,
      updatedAt
    }
  }
```

Use a seguinte query para buscar todas series cadastradas

```graphql
  query {
    series {
      id,
      title,
      description,
      categoryId,
      releaseDate,
      createdAt,
      updatedAt
      category {
        id
        name,
        description,
        series {
          title
        }
      }
    }
  }
```

Use a seguinte query para buscar uma serie por seu id

```graphql
  query {
    serie (id: 1) {
      id,
      title,
      description,
      categoryId,
      releaseDate,
      createdAt,
      updatedAt
      category {
        id
        name,
        description,
        series {
          title
        }
      }
    }
  }
```

Use a seguinte mutation para remover serie por seu id

```graphql
  mutation {
    removeSerie(id: 1)
  }
```
