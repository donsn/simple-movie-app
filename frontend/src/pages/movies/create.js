import React from 'react';
import { useNavigate } from 'react-router-dom';
import { FlexContainer, Form } from './styles';
import { useGetMovieGenresQuery, useCreateMovieMutation} from '../../api/movies';
import { HashLoader } from 'react-spinners';
import { useFormik } from 'formik';
import { CountryInput, InputField, MultiSelect, transformOutput } from '../../components/inputs';
import { Button } from '../../components/buttons';
import { showMessage, MessageTypes } from '../../components/toast';
import { slugify } from '../../utilities/slugify';
import { uploadImageAsync } from '../../utilities/images/uploader';



export default function CreateMoviePage() {
  const { data: genres, loading: genresIsLoading } = useGetMovieGenresQuery();
  const [createMovie, { isLoading }] = useCreateMovieMutation();
  const navigate = useNavigate();

  const handleSubmit = (values) => {
    uploadImageAsync(values.photo).then((res) => {
      if (res.uploaded) {
        var payload = {
          ...values,
          slug: slugify(values.name),
          photo: res.data,
        }
        createMovie(payload).unwrap().then((res) => {
          if (res.status) {
            showMessage(MessageTypes.SUCCESS, 'Movie Created Successfully');
            navigate('/movies');
            return;
          }
          else {
            showMessage(MessageTypes.ERROR, res.message);
          }
        })
      }
      else {
        showMessage(MessageTypes.ERROR, res.message);
      }
    })
  };

  const formhandler = useFormik({
    initialValues: {
      name: '',
      description: '',
      genres: [],
      releaseDate: new Date(),
      rating: 1,
      ticketPrice: 0,
      country: '',
      photo: null,
    },
    onSubmit: handleSubmit,
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
          onChange={(values) => formhandler.setFieldValue("genres", transformOutput(values))}
          // value={formhandler.values.genres}
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
          min={1}
          max={5}
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
          onChange={(e) => formhandler.setFieldValue('photo', e.target.files[0])}
          required
        />

        <Button type="submit" disabled={isLoading}>
          {isLoading ? 'Loading...' : 'Create'}
        </Button>
      </Form>
    </FlexContainer>
  );
}
