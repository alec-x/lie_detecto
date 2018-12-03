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
    x_data = data.reshape(1, data.shape[0], data.shape[1]);
    model = load_model('lie_detector_model.h5')
    # 5. make predictions
    predictions = model.predict(x_data)
    print(predictions[0, 0])
if __name__ == "__main__":
    main()
