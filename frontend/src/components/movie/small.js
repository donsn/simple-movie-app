import React from 'react';
import { Link } from 'react-router-dom';
import { slugify } from '../../utilities/slugify';

export default function SmallMovieView() {
  return (
    <Link to={`/movies/${slugify('title of life')}`}>
      <h2>Movie Title</h2>
      <p>Movie Description</p>
      <img src="https://via.placeholder.com/300x450" alt="Movie Poster" />
      <p>Released: {new Date().getFullYear()}</p>
    </Link>
  );
}
