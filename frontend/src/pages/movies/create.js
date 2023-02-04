import React from 'react';
import { FlexContainer, Form } from './styles';
import { useGetMovieGenresQuery, useCreateMovieMutation } from '../../api/movies';
import { HashLoader } from 'react-spinners';
import { useFormik } from 'formik';
import { CountryInput, InputField, MultiSelect } from '../../components/inputs';
import { Button } from '../../components/buttons';



export default function CreateMoviePage() {
  const { data: genres, loading: genresIsLoading } = useGetMovieGenresQuery();
  const [createMovie, { isLoading }] = useCreateMovieMutation();

  const formhandler = useFormik({
    initialValues: {
      name: '',
      description: '',
      genres: [],
      releaseDate: new Date(),
      rating: 0,
      ticketPrice: 0,
      country: '',
      photo: null,
    },
    onSubmit: (values) => {
      createMovie(values);
    },
  });

  if (genresIsLoading) {
    return (
      <FlexContainer>
        <HashLoader color="#f50057" />
      </FlexContainer>
    )
  }

  return (
    <FlexContainer>
      <Form onSubmit={formhandler.handleSubmit}>
        <h1>Create Movie</h1>
        <InputField
          type="text"
          name="name"
          id="name"
          label={'Movie Name'}
          onChange={formhandler.handleChange}
          value={formhandler.values.title}
          required
        />
         <InputField
          type="text"
          name="description"
          id="description"
          label={'Description'}
          onChange={formhandler.handleChange}
          value={formhandler.values.description}
          required
        />
        <MultiSelect
          label="Genre"
          options={genres}
          name="genreId"
          id="genreId"
          onChange={formhandler.handleChange}
          value={formhandler.values.genres}
          required
        >
        </MultiSelect>
        <InputField
          type="date"
          name="releaseDate"
          id="releaseDate"
          label={'Release Date'}
          onChange={formhandler.handleChange}
          value={formhandler.values.releaseDate}
          required
        />
        <InputField
          type="number"
          name="rating"
          id="rating"
          label={'Rating'}
          onChange={formhandler.handleChange}
          value={formhandler.values.rating}
          required
        />
        <InputField
          type="number"
          name="ticketPrice"
          id="ticketPrice"
          label={'Ticket Price'}
          onChange={formhandler.handleChange}
          value={formhandler.values.ticketPrice}
          required
        />
        <CountryInput
          type="text"
          name="country"
          id="country"
          label={'Country'}
          onChange={(val) => formhandler.setFieldValue('country', val)}
          value={formhandler.values.country}
          required
        />
        <InputField
          type="file"
          accept="image/*"
          name="photo"
          id="photo"
          label={'Photo'}
          onChange={formhandler.handleChange}
          value={formhandler.values.photo}
          required
        />    
       
        <Button type="submit" disabled={isLoading}>
          {isLoading ? 'Loading...' : 'Create'}
        </Button>
      </Form>
    </FlexContainer>
  );
}
