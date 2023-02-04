import React from 'react';
import { FlexContainer } from './styles';
import { useGetMovieGenresQuery, useCreateMovieMutation } from '../../api/movies';
import { HashLoader } from 'react-spinners';


export default function CreateMoviePage() {
  const { data: genres, loading: genresIsLoading } = useGetMovieGenresQuery();

  if(genresIsLoading) {
    return (
      <FlexContainer>
        <HashLoader color="#f50057" />
      </FlexContainer>
    )
  }
  
  return (
    <FlexContainer>
    
    </FlexContainer>
  );
}
