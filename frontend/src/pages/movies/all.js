import React from 'react';
import SmallMovieView from '../../components/movie/small';

export default function MovieListPage() {
  return (
    <div>
      <h1>All Movies</h1>
      <div>
        <SmallMovieView/>
      </div>
    </div>
  );
}
