import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { retrieveContent } from '../../utilities/storage';
import { BASE_URL } from '../base';

export const moviesApi = createApi({
    reducerPath: 'moviesApi',
    baseQuery: fetchBaseQuery({
        baseUrl: BASE_URL,
        prepareHeaders: (headers) => {
            const access_token = retrieveContent("x_token");
            headers.set("content-type", "application/json");
            if (access_token) {
                headers.set("authorization", `Bearer ${access_token}`);
            }
            return headers;
        }
    }),
    endpoints: (builder) => ({
        createMovie: builder.mutation({
            query: (movie) => ({
                url: '/movies',
                method: 'POST',
                body: movie,
            }),
        }),
        getMovieGenres: builder.query({
            query: () => ({
                url: '/movies/genres',
                method: 'GET',
            })
        }),
        getMovies: builder.query({
            query: () => ({
                url: '/movies',
                method: 'GET',
            })
        }),
        getMovieBySlug: builder.query({
            query: (slug) => ({
                url: `/movies/slug/${slug}`,
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
} = moviesApi;