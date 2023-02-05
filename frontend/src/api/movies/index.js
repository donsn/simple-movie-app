import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { retrieveContent } from '../../utilities/storage';
import { BASE_URL } from '../base';

export const moviesApi = createApi({
    reducerPath: 'moviesApi',
    baseQuery: fetchBaseQuery({
        baseUrl: BASE_URL,
        prepareHeaders: async (headers) => {
            const access_token = await retrieveContent("x-token");

            headers.set("content-type", "application/json");
            if (access_token) {
                headers.set("Authorization", `Bearer ${access_token}`);
            }
            return headers;
        }
    }),
    endpoints: (builder) => ({
        createMovie: builder.mutation({
            query: (movie) => ({
                url: 'api/movies',
                method: 'POST',
                body: movie,
            }),
        }),
        addCommentToMovie: builder.mutation({
            query: (payload) => ({
                url: `api/movies/${payload.movieId}/comment`,
                method: 'POST',
                body: payload.comment,
            }),
        }),
        getMovieGenres: builder.query({
            query: () => ({
                url: 'api/movies/genres',
                method: 'GET',
            })
        }),
        getMovies: builder.query({
            query: () => ({
                url: 'api/movies',
                method: 'GET',
            })
        }),
        getMovieBySlug: builder.query({
            query: (slug) => ({
                url: `api/movies/slug/${slug}`,
                method: 'GET',
            })
        }),
    }),
});

export const {
    useGetMoviesQuery,
    useGetMovieGenresQuery,
    useGetMovieBySlugQuery,
    useCreateMovieMutation,
    useAddCommentToMovieMutation,
} = moviesApi;