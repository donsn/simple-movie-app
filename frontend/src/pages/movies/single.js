import React from 'react';
import { HashLoader } from 'react-spinners';
import { useParams } from 'react-router-dom';
import LargeMovieView from '../../components/movie/large';
import { FlexContainer } from './styles';
import { useGetMovieBySlugQuery } from '../../api/movies';

export default function SingleMoviePage() {
  const { slug } = useParams();
  const { data: movie, isLoading } = useGetMovieBySlugQuery(slug);

  if (isLoading) {
    return <FlexContainer>
          <HashLoader color='#4FB286'>Loading...</HashLoader>
    </FlexContainer>
  }

  return (
    <FlexContainer>
      <LargeMovieView movie={movie}/>
    </FlexContainer>
  );
}
