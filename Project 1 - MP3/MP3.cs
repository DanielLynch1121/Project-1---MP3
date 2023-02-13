/**
*--------------------------------------------------------------------
* File name: {MP3.cs}
* Project name: {Project 1 - MP3}
*--------------------------------------------------------------------
* Author’s name and email: {Daniel Lynch ynchda@etsu.edu}
* Course-Section: {002}
* Creation Date: {02/02/2023}
* -------------------------------------------------------------------
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1___MP3
{
    internal class MP3
    {
        private string _songTitle;
        private string _artist;
        private string _songReleaseDate;
        private double _playbackTimeInMinutes;
        private Genre _genre;
        private decimal _downloadCost;
        private double _fileSizeInMBs;
        private string _albumCoverPhoto;

        public string GetSongTitle()
        {
            return _songTitle;
        }
        public string GetArtist() 
        { 
            return _artist;
        }
        public string GetSongReleaseDate()
        {
            return _songReleaseDate;
        }
        public double GetPlayBackTimeInMinutes()
        {
            return _playbackTimeInMinutes;
        }
        public Genre GetGenre()
        {
            return _genre;
        }
        public decimal GetDownloadCost() 
        {
            return _downloadCost;
        }
        public double GetFileSizeInMBs() 
        {
            return _fileSizeInMBs;
        }
        public string GetAlbumCoverPhoto() 
        {
            return _albumCoverPhoto;
        }
        public void SetSongTitle(string songTitle)
        {
            _songTitle = songTitle;
        }
        public void SetArtist(string artist) 
        {
            _artist = artist;
        }
        public void SetSongReleaseDate(string songReleaseDate)
        {
            _songReleaseDate = songReleaseDate;
        }
        public void SetPlayBackTimeInMinutes(double playbackTimeInMinutes)
        {
            if(playbackTimeInMinutes > 0)
            {
                _playbackTimeInMinutes = playbackTimeInMinutes;
            }
            else
            {
                _playbackTimeInMinutes = 3.32;
            }
        }
        public void SetGenre(Genre genre)
        {
            _genre = genre;
        }
        public void SetDownlodCost(decimal downlodCost)
        {
            if(downlodCost > 0) 
            {
                _downloadCost = downlodCost;
            }
            else
            {
                _downloadCost = 1;
            }
        }
        public void SetFileSizeInMSs(double fileSizeInMBs)
        {
            if (fileSizeInMBs > 0)
            {
                _fileSizeInMBs = fileSizeInMBs;
            }
            else
            {
                _fileSizeInMBs = 6.6;
            }
        }
        public void SetAlbumCoverPhoto(string albumCoverPhoto)
        {
            _albumCoverPhoto = albumCoverPhoto;
        }
        public MP3()
        {
            SetSongTitle("Title");
            SetArtist("Artist");
            SetSongReleaseDate("MM/DD/YYYY");
            SetPlayBackTimeInMinutes(3.32);
            SetGenre(Genre.Other);
            SetDownlodCost(1);
            SetFileSizeInMSs(6.6);
            SetAlbumCoverPhoto("photos\\FunkyTown.jpg");
        }
        public MP3(string songTitle, string artist, string songReleaseDate, double playbackTimeInMinutes, Genre genre, decimal downloadCost, double fileSizeInMBs, string albumCoverPhoto)
        {
            SetSongTitle(songTitle);
            SetArtist(artist);
            SetSongReleaseDate(songReleaseDate);
            SetPlayBackTimeInMinutes(playbackTimeInMinutes);
            SetGenre(genre);
            SetDownlodCost(downloadCost);
            SetFileSizeInMSs(fileSizeInMBs);
            SetAlbumCoverPhoto(albumCoverPhoto);
        }
        public MP3(MP3 existing)
        {
            SetSongTitle(existing.GetSongTitle());
            SetArtist(existing.GetArtist());
            SetSongReleaseDate(existing.GetSongReleaseDate());
            SetPlayBackTimeInMinutes(existing.GetPlayBackTimeInMinutes());
            SetGenre(existing.GetGenre());
            SetDownlodCost(existing.GetDownloadCost());
            SetFileSizeInMSs(existing.GetFileSizeInMBs());
            SetAlbumCoverPhoto(existing.GetAlbumCoverPhoto());
        }
        public override string ToString()
        {
            string info = "";

            info += $"\n         Title: {_songTitle}";
            info += $"\n        Artist: {_artist}";
            info += $"\n  Release Date: {_songReleaseDate}";         info += $"                Genre:        {_genre}";
            info += $"\n Download Cost: {_downloadCost}";            info += $"             File Size:        {_fileSizeInMBs}";
            info += $"\n Song Playtime: {_playbackTimeInMinutes}";   info += $"           Album Photo:        {_albumCoverPhoto}";

            return info;
        }
    }
}
