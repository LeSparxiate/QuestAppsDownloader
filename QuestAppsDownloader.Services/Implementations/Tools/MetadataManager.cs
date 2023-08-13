using QuestAppsDownloader.DTO.DTOs;
using System.Data;
using System.Globalization;
using System.Reflection;

namespace QuestAppsDownloader.Services.Implementations.Tools;

public class MetadataManager
{
    private const string MetadataFileLocation = "./metadata/VRP-GameList.txt";
    private const string DateFormat = "yyyy-MM-dd HH:mm UTC";

    public static DataTable LoadMetadata()
    {
        var metadata = new List<Metadata>();
        var rows = File.ReadAllLines(MetadataFileLocation).Select(a => a.Split(';')).Skip(1).ToList();

        foreach (var row in rows)
        {
            metadata.Add(new Metadata
            {
                GameName = row[0],
                ReleaseName = row[1],
                PackageName = row[2],
                Version = row[3],
                LastUpdated = DateTime.ParseExact(row[4], DateFormat, CultureInfo.InvariantCulture),
                Size = int.Parse(row[5])
            });
        }

        return ListToDataTable(metadata);
    }

    private static DataTable ListToDataTable<T>(List<T> items)
    {
        var dataTable = new DataTable(typeof(T).Name);

        var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (var prop in props)
            dataTable.Columns.Add(prop.Name);

        foreach (var item in items)
        {
            var values = new object[props.Length];
            for (int i = 0; i < props.Length; i++)
                values[i] = props[i].GetValue(item, null);

            dataTable.Rows.Add(values);
        }

        return dataTable;
    }
}
