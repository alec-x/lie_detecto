import os
import pandas
import glob
import numpy
from pandas import concat
from keras.models import Sequential, load_model
from keras.layers import Dense, LSTM, Activation
import h5py
from numpy.random import seed
from tensorflow import set_random_seed

def main():
    filename = "facevector.txt"
    data = pandas.read_csv(filename, delimiter=',', 
                           low_memory=False, index_col='time').values
    x_data_face = data.reshape(1, data.shape[0], data.shape[1]);

    filename = "heartvector.txt"
    data = pandas.read_csv(filename, delimiter=',', 
                           low_memory=False, index_col='time').values[0:1000]
    x_data_heart = data.reshape(1, data.shape[0], data.shape[1]);

    model_face = load_model('lie_detector_model.h5')
    model_heart = load_model('lie_detector_model_heart.h5')
    # 5. make predictions
    predictions_face = model_face.predict(x_data_face)
    predictions_heart = model_heart.predict(x_data_heart)
    print(predictions_face[0, 0])
    print(predictions_heart[0, 0])

if __name__ == "__main__":
    main()
