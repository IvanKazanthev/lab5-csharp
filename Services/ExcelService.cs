using System;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using LAB5.Models;

namespace LAB5.Services
{
    public class ExcelService
    {
        public void Load(
            string path,
            List<Country> countries,
            List<Club> clubs,
            List<Achievement> achievements)
        {
            using FileStream file = File.OpenRead(path);
            HSSFWorkbook book = new HSSFWorkbook(file);

            ISheet countrySheet = book.GetSheetAt(0);
            ISheet clubSheet = book.GetSheetAt(1);
            ISheet achievementSheet = book.GetSheetAt(2);

            for (int i = 1; i <= countrySheet.LastRowNum; i++)
            {
                IRow row = countrySheet.GetRow(i);

                if (row == null)
                {
                    continue;
                }

                countries.Add(new Country(
                    ReadInt(row, 0),
                    ReadText(row, 1)));
            }

            for (int i = 1; i <= clubSheet.LastRowNum; i++)
            {
                IRow row = clubSheet.GetRow(i);

                if (row == null)
                {
                    continue;
                }

                clubs.Add(new Club(
                    ReadInt(row, 0),
                    ReadText(row, 1),
                    ReadInt(row, 2)));
            }

            for (
                int i = 1;
                i <= achievementSheet.LastRowNum;
                i++)
            {
                IRow row = achievementSheet.GetRow(i);

                if (row == null)
                {
                    continue;
                }

                Achievement a = new Achievement();

                a.ClubId = ReadInt(row, 0);
                a.Gold = ReadInt(row, 1);
                a.Silver = ReadInt(row, 2);
                a.Bronze = ReadInt(row, 3);
                a.Cup = ReadInt(row, 4);
                a.LostCup = ReadInt(row, 5);
                a.ChampionsLeague = ReadInt(row, 6);
                a.LostChampionsLeague = ReadInt(row, 7);
                a.EuropaLeague = ReadInt(row, 8);
                a.LostEuropaLeague = ReadInt(row, 9);
                a.CupWinnersCup = ReadInt(row, 10);
                a.LostCupWinnersCup = ReadInt(row, 11);
                a.ConferenceLeague = ReadInt(row, 12);
                a.LostConferenceLeague = ReadInt(row, 13);

                achievements.Add(a);
            }

            book.Close();
        }

        private int ReadInt(IRow row, int index)
        {
            ICell cell = row.GetCell(index);

            if (cell == null)
            {
                return 0;
            }

            if (cell.CellType == CellType.Numeric)
            {
                return (int)cell.NumericCellValue;
            }

            int number;

            if (int.TryParse(cell.ToString(), out number))
            {
                return number;
            }

            return 0;
        }

        private string ReadText(IRow row, int index)
        {
            ICell cell = row.GetCell(index);

            if (cell == null)
            {
                return "";
            }

            return cell.ToString();
        }

        public void Save(
            string path,
            List<Country> countries,
            List<Club> clubs,
            List<Achievement> achievements)
        {
            HSSFWorkbook book;

            using (FileStream file = File.OpenRead(path))
            {
                book = new HSSFWorkbook(file);
            }

            SaveCountries(book.GetSheetAt(0), countries);
            SaveClubs(book.GetSheetAt(1), clubs);
            SaveAchievements(
                book.GetSheetAt(2),
                achievements);

            using (FileStream file = File.Create(path))
            {
                book.Write(file);
            }

            book.Close();
        }

        private void ClearRows(ISheet sheet)
        {
            for (int i = sheet.LastRowNum; i >= 1; i--)
            {
                IRow row = sheet.GetRow(i);

                if (row != null)
                {
                    sheet.RemoveRow(row);
                }
            }
        }

        private void SaveCountries(
            ISheet sheet,
            List<Country> countries)
        {
            ClearRows(sheet);

            for (int i = 0; i < countries.Count; i++)
            {
                IRow row = sheet.CreateRow(i + 1);

                row.CreateCell(0).SetCellValue(
                    countries[i].Id);

                row.CreateCell(1).SetCellValue(
                    countries[i].Name);
            }
        }

        private void SaveClubs(
            ISheet sheet,
            List<Club> clubs)
        {
            ClearRows(sheet);

            for (int i = 0; i < clubs.Count; i++)
            {
                IRow row = sheet.CreateRow(i + 1);

                row.CreateCell(0).SetCellValue(
                    clubs[i].Id);

                row.CreateCell(1).SetCellValue(
                    clubs[i].Name);

                row.CreateCell(2).SetCellValue(
                    clubs[i].CountryId);
            }
        }

        private void SaveAchievements(
            ISheet sheet,
            List<Achievement> achievements)
        {
            ClearRows(sheet);

            for (int i = 0; i < achievements.Count; i++)
            {
                Achievement a = achievements[i];
                IRow row = sheet.CreateRow(i + 1);

                row.CreateCell(0).SetCellValue(a.ClubId);
                row.CreateCell(1).SetCellValue(a.Gold);
                row.CreateCell(2).SetCellValue(a.Silver);
                row.CreateCell(3).SetCellValue(a.Bronze);
                row.CreateCell(4).SetCellValue(a.Cup);
                row.CreateCell(5).SetCellValue(a.LostCup);
                row.CreateCell(6).SetCellValue(
                    a.ChampionsLeague);
                row.CreateCell(7).SetCellValue(
                    a.LostChampionsLeague);
                row.CreateCell(8).SetCellValue(
                    a.EuropaLeague);
                row.CreateCell(9).SetCellValue(
                    a.LostEuropaLeague);
                row.CreateCell(10).SetCellValue(
                    a.CupWinnersCup);
                row.CreateCell(11).SetCellValue(
                    a.LostCupWinnersCup);
                row.CreateCell(12).SetCellValue(
                    a.ConferenceLeague);
                row.CreateCell(13).SetCellValue(
                    a.LostConferenceLeague);
            }
        }
    }
}