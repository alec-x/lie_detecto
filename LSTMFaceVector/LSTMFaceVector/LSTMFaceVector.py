import os
import pandas
import glob
import numpy
from pandas import concat
from keras.models import Sequential
from keras.layers import Dense, LSTM, Activation
from numpy.random import seed
from tensorflow import set_random_seed

def main():
    seed(10)
    set_random_seed(232)
    path = 'C:\\Repos\\mech423final\\LSTMFaceVector\\trainingData'
    i = 0
    y_data = numpy.array([])
    for filename in glob.glob(os.path.join(path, '*.txt')):
        if i == 0:
            data = pandas.read_csv(filename, delimiter=',', 
                                   low_memory=False, index_col='time').values
        else:
            datatemp = pandas.read_csv(filename, delimiter=',', 
                                   low_memory=False, index_col='time').values
            data = numpy.dstack((data, datatemp))
        y_data = numpy.append(y_data, os.path.basename(filename).split("_")[0])        
        i += 1

    x_data = data.reshape(data.shape[2], data.shape[0], data.shape[1]); # sample,timestep, feature
    # machinelearningmastery.com/5-step-life-cycle-long-short-term-memory-models-keras/
    
    model = Sequential()
    model.add(LSTM(256, input_shape=(50,102), return_sequences=True)) #the 256 is semi-arbitrary?
    model.add(LSTM(256))
    model.add(Dense(1)) 
    model.add(Activation('sigmoid'))
    model.compile(optimizer='RMSprop', loss='mean_squared_error')

    history = model.fit(x_data, y_data, epochs=1000, batch_size=len(x_data))
    
    loss = model.evaluate(x_data, y_data)
    print(loss)
    # 5. make predictions
    predictions = model.predict(x_data)
    print(y_data)
    print(predictions[:, 0])
if __name__ == "__main__":
    main()
