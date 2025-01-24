# OOP H2 Pokedex
## **Introduktion**

Pokedex System er en simpel applikation, der giver brugere mulighed for at administrere en liste over Pokémon. Programmet understøtter login med sikker password-hash og tilbyder forskellige funktioner såsom søgning, visning, tilføjelse og redigering af Pokémon.

---

## **Funktioner**
- **Login**: Brugernavn og SHA-256 hashede passwords valideres fra en tekstfil.
- **Tilføj Pokémon**: Vælg og tilføj Pokémon fra en foruddefineret liste.
- **Se Pokémon**: Vis Pokémon med sidestyring for nem navigation.
- **Søg Pokémon**: Find Pokémon baseret på navn eller type.
- **Rediger Pokémon**: Opdater Pokémon-detaljer som navn, type og styrke.
- **Slet Pokémon**: Fjern Pokémon fra systemet.
- **Gæstetilstand**: Giver begrænset adgang til at se og søge Pokémon uden login.

---

## **Komponenter**
1. **LogInMetode.cs**:
   - Håndterer loginprocessen.
   - Validerer brugeroplysninger mod en ekstern fil (`Pokedexlogins.txt`).
   - Brugte passwords hashes med SHA-256 for sikkerhed.

2. **Menu.cs**:
   - Implementerer menufunktioner, herunder at tilføje, se, søge, redigere og slette Pokémon.
   - Understøtter gæstetilstand og giver begrænset adgang uden login.

3. **Program.cs**:
   - Applikationens startpunkt.
   - Giver brugeren mulighed for at vælge mellem login eller gæstetilstand.

---

## **Installation**
### **Forudsætninger**
- .NET Framework version 5.0 eller nyere.
- Følgende filer skal oprettes og placeres korrekt:
  - **`Pokedexlogins.txt`**: Indeholder brugernavn og hashede passwords.
  - **`PokemonDokument.txt`**: Indeholder Pokémon-data i tekstformat.

### **Trin**
1. Download eller klon projektet.
2. Åbn projektet i en IDE som Visual Studio.
3. Sørg for, at filerne **`Pokedexlogins.txt`** og **`PokemonDokument.txt`** findes på de rigtige stier.
4. Byg og kør projektet via IDE'en.

---

## **Brugergrænseflade**
Ved opstart af programmet præsenteres brugeren for følgende valg:
- **a**: Log ind med brugernavn og password.
- **b**: Fortsæt uden login som gæst.

### **Hovedmenu**
Efter login præsenteres en menu med følgende muligheder:
- **a**: Tilføj Pokémon.
- **b**: Se Pokémon.
- **c**: Søg Pokémon.
- **d**: Rediger Pokémon.
- **e**: Slet Pokémon.
- **f**: Log ud.

Gæstetilstand giver kun adgang til:
- **1**: Se Pokémon.
- **2**: Søg Pokémon.

---

## **Filstruktur**
- **`LogInMetode.cs`**: Håndtering af login og brugervalidering.
- **`Menu.cs`**: Logik til menu og Pokémon-håndtering.
- **`Program.cs`**: Applikationens hovedindgang.

---

## **Krav**
- **Platform**: .NET Framework version 5.0 eller nyere.
- **Eksterne filer**:
  - **`Pokedexlogins.txt`**: Indeholder brugeroplysninger (brugernavn og password).
  - **`PokemonDokument.txt`**: Indeholder Pokémon-liste i tekstformat.

