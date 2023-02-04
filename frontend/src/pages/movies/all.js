import React from 'react';
import SmallMovieView from '../../components/movie/small';
import { FlexContainer, Title } from './styles';
import { useGetMoviesQuery } from '../../api/movies';

export default function MovieListPage() {
  const { data, error, isLoading } = useGetMoviesQuery();
  if (isLoading) {
    return <div>Loading...</div>;
  }
  console.log(data);

  if(error) {
    return <div>Something went wrong</div>;
  }

  return (
    <div>
      <Title>All Movies</Title>
      <FlexContainer>
        {data.map((movie) => (
          <SmallMovieView key={movie.id} movie={movie} />
        ))}
      </FlexContainer>
    </div>
  );
}
