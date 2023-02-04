import { Navigate } from 'react-router-dom';
import LoginPage from './auth/login';
import SignupPage from './auth/signup';
import MovieListPage from './movies/all';
import SingleMoviePage from './movies/single';
import CreateMoviePage from './movies/create';

export const Routes = [
    {
        path: '/',
        element: <Navigate to="/movies" />,
    },
    {
        path: '/movies',
        element: <MovieListPage />,
    },
    {
        path: 'movies/create',
        element: <CreateMoviePage />,
    },
    {
        path: '/movies/:slug',
        element: <SingleMoviePage />,
    },
    // Auth routes
    {
        path: '/login',
        element: <LoginPage />,
    },
    {
        path: '/register',
        element: <SignupPage />,
    }

]