import os
import pandas
import glob
import numpy
from pandas import DataFrame
from pandas import concat
from keras.models import Sequential
from keras.layers import Dense, LSTM, Activation

def main():
    path = 'C:\Repos\mech423final\LSTMFaceVector\LSTMFaceVector'
    i = 0
    for filename in glob.glob(os.path.join(path, '*.txt')):
        if i == 0:
            data = pandas.read_csv(filename, delimiter=',', 
                                   low_memory=False, index_col='time').values
        else:
            datatemp = pandas.read_csv(filename, delimiter=',', 
                                   low_memory=False, index_col='time').values
            data = numpy.dstack((data, datatemp))
        i += 1

    data = data.reshape(data.shape[2], data.shape[0], data.shape[1]); # sample,timestep, feature
    # machinelearningmastery.com/5-step-life-cycle-long-short-term-memory-models-keras/
    
    model = Sequential()
    model.add(LSTM(256, input_shape=(50,51))) #the 256 is semi-arbitrary?
    model.add(Dense(256)) 
    model.add(Activation('sigmoid'))
    model.compile(optimizer='sgd', loss='mean_squared_error')

if __name__ == "__main__":
    main()
