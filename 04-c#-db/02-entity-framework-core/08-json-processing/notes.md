# JSON Processing

## Information

- File.ReadAllText()
- Library integrated into .NET
    - Terrible
    - Do not use it
- Json.NET
    - Use this
    - By Newtonsoft
- Minified -> file.json.min

## Functionality

- JsonConvert
    - .SerializeObject()
        - new JsonSerializerSettings()
    - .DeserializeObject<T>()
    - .DeserializeAnonymousType()
    - Works with collections and objects
- new DefaultContractResolver()
    - NamingStrategy

## Attributes

- [JsonProperty("SomeProp")]
- [JsonIgnore]
